# Getting started

## Prerequisites

Install the .NET 10 SDK. The repository expects a compatible version (see `global.json` in the repo root).

## Clone and build

```powershell
git clone <repository-url>
cd Frank.EtherRipple
dotnet build Frank.EtherRipple.slnx
```

## Run from another app

`Frank.EtherRipple.Server` is a **class library**. Reference it from a console or worker host and start a multi-endpoint server:

```csharp
using Frank.EtherRipple.Server;
using System.Net;

var http = ProtocolFactory.Create("HTTP", 8080, IPAddress.Loopback);
var echo = new CustomProtocol("Echo", 9090, IPAddress.Loopback);

var server = new RippleServer()
    .Map(http, ProtocolHandlers.MinimalHttpHtmlAsync)
    .Map(echo, ProtocolHandlers.EchoAsync);

await server.RunAsync(stoppingToken); // listens on 8080 and 9090 until cancelled
```

For a single echo port (legacy helper), use `Frank.EtherRipple.Server.Internals.SocketServer`.

## Publish a build

From the repo root:

```powershell
./publish.ps1
```

This runs `dotnet publish` on `Frank.EtherRipple.Server` and writes outputs under `.artifacts/publish/`.

## Next steps

- Read [architecture.md](architecture.md) for how protocols and listeners fit together.
- See [AGENT.md](../AGENT.md) if you are using AI assistants in this codebase.
