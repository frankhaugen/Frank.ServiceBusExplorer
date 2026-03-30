# Agent notes (Frank.EtherRipple)

Use this file when editing this repository in an AI-assisted IDE.

## What this repo is

**Frank.EtherRipple** is a .NET library for a multi-protocol TCP server (“ripple” routing across protocol handlers). It is **not** an Azure Service Bus tool; an unrelated **Frank.ServiceBusExplorer** tree used to live alongside it and has been removed to avoid confusion.

## Tooling

- **Solution:** `Frank.EtherRipple.slnx` (SLNX). Prefer the CLI: `dotnet build Frank.EtherRipple.slnx`.
- **TFM:** `net10.0` from `Directory.Build.props`. Do not downgrade individual projects without a reason.
- **SDK:** `global.json` pins `10.0.201` with `rollForward: latestFeature`.

## Code conventions

- Match existing style; C# formatting is governed by `.editorconfig`.
- Keep changes scoped to the request; avoid drive-by refactors in unrelated protocols.
- `RippleRoute` pairs an `IProtocol` with a `ProtocolConnectionHandler` (`Stream` + protocol + cancellation). No ASP.NET Core dependency.

## Where things live

- **Protocols:** `Frank.EtherRipple.Server/Protocols/*.cs`
- **Socket accept loop:** `Internals/SocketServer.cs`, `ProtocolListener.cs`
- **Contracts:** `IProtocol.cs`, `Protocol.cs`, `ProtocolFactory.cs`, `ProtocolExtensions.cs`

## Checks before finishing

```powershell
dotnet build Frank.EtherRipple.slnx -c Release
```

## Human-oriented docs

See `docs/getting-started.md` and `docs/architecture.md`.
