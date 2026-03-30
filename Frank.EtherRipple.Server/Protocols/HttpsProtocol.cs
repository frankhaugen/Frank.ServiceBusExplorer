using System.Net;

namespace Frank.EtherRipple.Server;

public class HttpsProtocol : Protocol
{
    public override string Name => "HTTPS";
    public override int Port { get; set; } = 443; // Default HTTPS port
}