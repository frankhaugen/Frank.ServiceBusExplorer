using System.Net;

namespace Frank.EtherRipple.Server;

public class CustomProtocol : Protocol
{
    public CustomProtocol(string name, int port)
    {
        Name = name;
        Port = port;
    }

    public CustomProtocol(string name, int port, IPAddress address)
    {
        Name = name;
        Port = port;
        Address = address;
    }
    
    public override string Name { get; }
    public sealed override int Port { get; set; }
}