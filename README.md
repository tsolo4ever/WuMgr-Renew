# WuMgr — Update Manager for Windows

A fork of [DavidXanatos/wumgr](https://github.com/DavidXanatos/wumgr) with security hardening, new features, and .NET 10 modernization.

---

## Overview

WuMgr is a Windows Update management tool that gives you direct control over the Windows Update Agent API — the same engine Windows itself uses. It lets you search, download, install, and uninstall updates with the granular control that Windows 10/11 Home and Pro no longer expose in their Settings UI.

Inspired by [Windows Update MiniTool (WUMT)](https://www.majorgeeks.com/files/details/windows_update_minitool.html), but written entirely in C# / .NET and open source.

---

## Requirements

- Windows 10 or 11
- .NET 10 runtime
- Administrator privileges (required by the Windows Update Agent API)

---

## Features

### Update Management
- **Search** for pending, installed, and hidden updates via the Windows Update Agent API
- **Download** updates to a local folder for offline or deferred installation
- **Install** updates through WUA or manually from downloaded files (.msu, .msi, .cab, .exe, .zip)
- **Uninstall** updates using `wusa.exe`
- **Hide / unhide** updates to suppress unwanted entries
- **Update history** — view the full install/uninstall log from Windows

### Tray Icon
- Color-coded by highest-priority pending update:
  - Red — security / critical
  - Yellow — non-critical
  - Blue — driver
  - Gray — no pending updates
- **Blinks** gray ↔ priority color when a restart is required
- **Restart Now** context menu item appears automatically when a reboot is pending
- Balloon tip notifications for new updates and auto-update schedule

### Offline Mode
- Download `wsusscn2.cab` from Microsoft (or a custom URL) to scan for updates without connecting to Windows Update servers
- Scan entirely offline against a local cab file

### WiFi Connect for Updates
Designed for systems that are kept offline most of the time (kiosks, secure workstations, air-gapped machines):
- Select a saved Windows WiFi profile from the Options > WiFi tab
- **Connect before check** — automatically connects to the selected WiFi network before searching for updates
- **Disconnect after download** — automatically disconnects once the download completes; installation runs offline from the cached files
- Manual **Connect Now / Disconnect Now** button
- Connection status and profile selection persisted across sessions
- `mWifiConnectedByUs` flag ensures only connections *opened by WuMgr* are closed automatically

### Download Engine
- Resumable downloads — partial `.tmp` files are picked up on restart using HTTP `Range: bytes=X-` requests
- Up to 3 automatic retries on network errors, each attempt resuming from where the previous left off
- Falls back to a full restart if the server does not support range requests
- Real-time download speed display (KB/s) in the progress bar area
- URL scheme validation — only `http://` and `https://` URLs are accepted

### Update Cache
- Update lists are cached to `updates.json` using `System.Text.Json` (no external dependencies)
- Replaces the old INI-based P/Invoke cache; existing `updates.ini` files are migrated automatically on first run and then deleted
- Cache is written on a background thread — no UI freeze on large update lists

### Windows Update Agent Configuration (AU tab)
- Set automatic update behavior: Default, Disabled, Notification only, Download only, Scheduled installation, Managed by Admin
- Include/exclude driver updates from quality updates
- Block connections to Windows Update internet locations (force WSUS-only or fully offline)
- Disable / re-enable the Update Orchestrator (`UsoSvc`) and Windows Update Medic (`WaaSMedicSvc`) services
- Hide the Windows Update settings page from end users
- Control Microsoft Store automatic updates

### General Options
- **Offline Mode** — scan against a local wsusscn2.cab
- **Manual Download/Install** — download files to a folder and install them yourself
- Include superseded updates toggle
- Source selection (Windows Update, Microsoft Update, Windows Store, WSUS)
- Auto-update schedule: daily, weekly, or monthly with idle-time guard
- Skip UAC prompt via a scheduled task (no-UAC mode)
- Autostart with Windows (tray mode)
- Color mode: System default, Light (classic), Dark

---

## Changes from the Original

This fork ([DavidXanatos/wumgr](https://github.com/DavidXanatos/wumgr)) makes the following changes:

### Security
- Named pipe ACL narrowed from `Everyone` → current user SID only
- All `ProcessStartInfo.Arguments` string concatenation replaced with `ArgumentList` (eliminates shell injection)
- Zip slip protection on all archive extraction — path traversal entries are rejected
- KB number validated with `^\d+$` before being passed to `wusa.exe`
- URL scheme validation — non-http/https URLs rejected in downloader and update cache loader
- Service name whitelist in `GPO.ConfigSvc` — prevents registry path manipulation
- Registry rights reduced — `TakeOwnership` removed where not required
- Removed `-onclose` command-line argument that allowed arbitrary process execution by a non-admin

### New Features
- WiFi Connect for Updates (connect → check/download → auto-disconnect)
- Download resume with HTTP Range requests and automatic retry
- Tray icon blink on reboot required
- Restart Now tray context menu item
- Download speed display in progress UI

### Reliability & Performance
- JSON update cache replacing INI P/Invoke (`updates.json`, auto-migrates from `updates.ini`)
- Update history loaded off the UI thread at startup — form appears immediately
- Cache writes serialized via `SemaphoreSlim` + written to `.tmp` then atomically renamed — prevents corruption on concurrent updates
- `File.Move` with `overwrite: true` — atomic rename, eliminates TOCTOU race
- Download cancel/retry race fixed — `Canceled` flag checked before queued retry fires
- WiFi auto-disconnect fires on cancel and failure, not only on success
- `netsh` process calls timeout after 15 s (with kill) — prevents hang on unresponsive WLAN service
- Pipe fault errors logged in async read callbacks

### Code Quality
- Retargeted to .NET 10; `System.ServiceProcess.ServiceController` bumped to 10.0.6
- `using` declarations throughout; all `IDisposable` objects properly disposed
- `long` for file sizes (>2 GB support)
- `BeginInvoke` for non-blocking UI dispatch in async callbacks
- `ConcurrentQueue` (FIFO) replacing `ConcurrentStack` in IPC pipe client
- `Marshal.GetLastWin32Error()` replacing direct `GetLastError()` P/Invoke
- `async void` event handlers wrapped in `try/catch` — unhandled exceptions log instead of crashing
- `Stopwatch` replacing `DateTime.Now` deadline in WiFi connection wait — immune to clock adjustments
- Removed unused `using` directives, dead code, and German comments throughout

---

## License

GNU General Public License v3.0 — see the original project for full license text.

Original author: [David Xanatos](https://github.com/DavidXanatos)
