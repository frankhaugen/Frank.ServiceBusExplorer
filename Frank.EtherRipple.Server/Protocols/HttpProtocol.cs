using System.Net;

namespace Frank.EtherRipple.Server;

public class HttpProtocol : Protocol
{
    public override string Name => "HTTP";
    public override int Port { get; set; } = 80; // Default HTTP port
}