using System.Net;

namespace Frank.EtherRipple.Server.Internals;

public sealed class SocketServer
{
    private readonly RippleServer _ripple = new();

    public SocketServer(IPEndPoint bindEndPoint)
    {
        var protocol = new CustomProtocol("Echo", bindEndPoint.Port, bindEndPoint.Address);
        _ripple.Map(protocol, ProtocolHandlers.EchoAsync);
    }

    public Task RunAsync(CancellationToken cancellationToken = default) => _ripple.RunAsync(cancellationToken);
}
