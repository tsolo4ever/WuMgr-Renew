using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

class HttpTask
{
    const int BUFFER_SIZE    = 65536;
    const int MAX_RETRIES    = 3;
    const int READ_TIMEOUT_MS = 30_000;

    private static readonly HttpClient sClient = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };

    private readonly string     mUrl;
    private readonly string     mDlPath;
    private          string     mDlName;
    private          int        mRetryCount;
    private          CancellationTokenSource _cts;
    private readonly Dispatcher mDispatcher;

    public string DlPath => mDlPath;
    public string DlName => mDlName;

    public HttpTask(string url, string dlPath, string dlName = null, bool update = false)
    {
        mUrl        = url;
        mDlPath     = dlPath;
        mDlName     = dlName;
        mDispatcher = Dispatcher.CurrentDispatcher;
    }

    public bool Start()
    {
        if (!Uri.TryCreate(mUrl, UriKind.Absolute, out Uri uri) ||
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            AppLog.Line("Download rejected, invalid URL scheme: {0}", mUrl);
            return false;
        }
        mRetryCount = 0;
        _cts = new CancellationTokenSource();
        _ = RunAsync(uri, _cts.Token);
        return true;
    }

    public void Cancel() => _cts?.Cancel();

    private async Task RunAsync(Uri uri, CancellationToken ct)
    {
        while (true)
        {
            try
            {
                await DownloadOnceAsync(uri, ct);
                return;
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                AppLog.Line("Download cancelled: {0}", mUrl);
                FireFinished(-1, null);
                return;
            }
            catch (Exception e) when (!ct.IsCancellationRequested)
            {
                if (mRetryCount >= MAX_RETRIES)
                {
                    AppLog.Line("Download failed after {0} retries: {1}", MAX_RETRIES, e.Message);
                    FireFinished(-2, e);
                    return;
                }
                mRetryCount++;
                AppLog.Line("Download error, retrying ({0}/{1}): {2}", mRetryCount, MAX_RETRIES, e.Message);
            }
        }
    }

    private async Task DownloadOnceAsync(Uri uri, CancellationToken ct)
    {
        // Check for a partial file to resume
        long resumeOffset = 0;
        if (mDlName != null)
        {
            var tmp = new FileInfo(Path.Combine(mDlPath, mDlName + ".tmp"));
            if (tmp.Exists && tmp.Length > 0)
                resumeOffset = tmp.Length;
        }

        using var req = new HttpRequestMessage(HttpMethod.Get, uri);
        if (resumeOffset > 0)
        {
            req.Headers.Range = new RangeHeaderValue(resumeOffset, null);
            AppLog.Line("Resuming download from byte {0}: {1}", resumeOffset, mUrl);
        }

        using var resp = await sClient.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, ct);

        if (!resp.IsSuccessStatusCode)
            throw new HttpRequestException($"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}");

        bool isPartial = resp.StatusCode == HttpStatusCode.PartialContent;
        if (resumeOffset > 0 && !isPartial)
        {
            AppLog.Line("Server does not support resume, restarting: {0}", mUrl);
            resumeOffset = 0;
        }

        long? contentLen  = resp.Content.Headers.ContentLength;
        long  totalLength = contentLen.HasValue
            ? (isPartial ? resumeOffset + contentLen.Value : contentLen.Value)
            : -1;

        DateTime lastTime = resp.Content.Headers.LastModified?.LocalDateTime ?? DateTime.Now;

        if (mDlName == null)
        {
            string fn = resp.Content.Headers.ContentDisposition?.FileNameStar
                     ?? resp.Content.Headers.ContentDisposition?.FileName?.Trim('"')
                     ?? Path.GetFileName(resp.RequestMessage?.RequestUri?.AbsolutePath ?? "");
            mDlName = string.IsNullOrEmpty(fn) || fn[0] == '?'
                ? GetNextTempFile(mDlPath, "Download") : fn;
        }

        // Skip re-download if file is already complete
        if (!isPartial && totalLength > 0)
        {
            var existing = new FileInfo(Path.Combine(mDlPath, mDlName));
            if (existing.Exists && existing.Length == totalLength && existing.LastWriteTime == lastTime)
            {
                AppLog.Line("File already downloaded: {0}", Path.Combine(mDlPath, mDlName));
                FireFinished(0, null);
                return;
            }
        }

        Directory.CreateDirectory(mDlPath);

        string tmpPath = Path.Combine(mDlPath, mDlName + ".tmp");
        using var src = await resp.Content.ReadAsStreamAsync(ct);
        using var dst = isPartial && File.Exists(tmpPath)
            ? new FileStream(tmpPath, FileMode.Append, FileAccess.Write)
            : new FileStream(tmpPath, FileMode.Create,  FileAccess.Write);

        var  buf    = new byte[BUFFER_SIZE];
        long offset = resumeOffset;
        int  oldPct = -1;
        var  sw     = Stopwatch.StartNew();

        while (true)
        {
            int read;
            using (var readCts = CancellationTokenSource.CreateLinkedTokenSource(ct))
            {
                readCts.CancelAfter(READ_TIMEOUT_MS);
                try
                {
                    read = await src.ReadAsync(buf, 0, BUFFER_SIZE, readCts.Token);
                }
                catch (OperationCanceledException) when (!ct.IsCancellationRequested)
                {
                    throw new TimeoutException($"Read stalled for {READ_TIMEOUT_MS / 1000}s");
                }
            }
            if (read == 0) break;

            await dst.WriteAsync(buf, 0, read, ct);
            offset += read;

            int pct = totalLength > 0 ? (int)(100L * offset / totalLength) : -1;
            if (pct != oldPct)
            {
                oldPct = pct;
                long speed = sw.Elapsed.TotalSeconds > 0.1
                    ? (long)((offset - resumeOffset) / sw.Elapsed.TotalSeconds) : 0;
                int p = pct; long s = speed;
                _ = mDispatcher.BeginInvoke(new Action(() => Progress?.Invoke(this, new ProgressEventArgs(p, s))));
            }
        }

        // Atomic rename .tmp -> final
        try
        {
            File.Move(tmpPath, Path.Combine(mDlPath, mDlName), overwrite: true);
            try { File.SetLastWriteTime(Path.Combine(mDlPath, mDlName), lastTime); } catch { }
        }
        catch
        {
            AppLog.Line("Failed to rename download: {0}", tmpPath);
            mDlName += ".tmp";
        }

        FireFinished(0, null);
    }

    private void FireFinished(int errCode, Exception error) =>
        mDispatcher.BeginInvoke(new Action(() => Finished?.Invoke(this, new FinishedEventArgs(errCode, error))));

    public static string GetNextTempFile(string path, string baseName)
    {
        for (int i = 0; i < 10000; i++)
        {
            if (!File.Exists(Path.Combine(path, baseName + "_" + i + ".tmp")))
                return baseName + "_" + i;
        }
        return baseName;
    }

    // ── Event args ────────────────────────────────────────────────────────────

    public class FinishedEventArgs : EventArgs
    {
        public FinishedEventArgs(int errCode = 0, Exception error = null) { ErrCode = errCode; Error = error; }
        public string GetError() => Error != null ? Error.ToString()
            : ErrCode switch { 0 => "Ok", -1 => "Canceled", _ => ErrCode.ToString() };
        public bool      Success   => ErrCode == 0;
        public bool      Cancelled => ErrCode == -1;
        public int       ErrCode;
        public Exception Error;
    }

    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(int percent, long speed = 0) { Percent = percent; Speed = speed; }
        public int  Percent;
        public long Speed; // bytes/s
    }

    public event EventHandler<FinishedEventArgs> Finished;
    public event EventHandler<ProgressEventArgs> Progress;
}
