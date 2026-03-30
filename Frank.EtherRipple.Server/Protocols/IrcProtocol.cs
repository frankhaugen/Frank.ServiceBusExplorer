using System.Net;

namespace Frank.EtherRipple.Server;

public class IrcProtocol : Protocol
{
    public override string Name => "IRC";
    public override int Port { get; set; } = 6667; // Default IRC port
}