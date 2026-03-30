# Frank.EtherRipple

Multi-protocol TCP ripple server: one codebase listens on configured endpoints and routes traffic by protocol (HTTP, HTTPS, FTP, IRC, SFTP, custom, and similar stubs).

## Requirements

- [.NET SDK 10](https://dotnet.microsoft.com/download) (see `global.json` for the pinned version band).

## Build

```powershell
dotnet build Frank.EtherRipple.slnx
dotnet test   # when test projects exist
```

## Publish

```powershell
./publish.ps1
```

Output goes under `.artifacts/publish/` (see script).

## Documentation

- [Getting started](docs/getting-started.md)
- [Architecture](docs/architecture.md)
- [AGENT.md](AGENT.md) — notes for AI coding agents working in this repo

## Repository layout

| Path | Role |
|------|------|
| `Frank.EtherRipple.slnx` | XML solution (preferred over legacy `.sln`) |
| `Frank.EtherRipple.Server/` | Library: protocols, socket listener, routing types |
| `Directory.Build.props` | Shared `net10.0`, nullable, language version |
| `global.json` | SDK pin / roll-forward |

## License

See [LICENSE](LICENSE).
