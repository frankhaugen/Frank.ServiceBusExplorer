using System.Net;

namespace Frank.EtherRipple.Server;

public sealed class RippleRoute
{
    public IProtocol Protocol { get; }
    public ProtocolConnectionHandler Handler { get; }
    public EndPoint Endpoint => Protocol.GetEndPoint();

    public RippleRoute(IProtocol protocol, ProtocolConnectionHandler handler)
    {
        Protocol = protocol ?? throw new ArgumentNullException(nameof(protocol));
        Handler = handler ?? throw new ArgumentNullException(nameof(handler));
    }
}
