using System.Net;

namespace Frank.EtherRipple.Server;

public class IrcsProtocol : Protocol
{
    public override string Name => "IRCS";
    public override int Port { get; set; } = 6697; // Default IRCS port
}