using System.Net;

namespace Frank.EtherRipple.Server;

public abstract class Protocol : IProtocol
{
    public abstract string Name { get; }
    public abstract int Port { get; set; }

    public IPAddress Address { get; set; } = IPAddress.Any;
}