using System.Net;

namespace Frank.EtherRipple.Server;

public class FtpsProtocol : Protocol
{
    public override string Name => "FTPS";
    public override int Port { get; set; } = 990; // Default FTPS port
}