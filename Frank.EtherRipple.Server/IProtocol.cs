using System.Net;

namespace Frank.EtherRipple.Server;

public interface IProtocol
{
    string Name { get; }
    int Port { get; }
    IPAddress Address { get; set; }
}