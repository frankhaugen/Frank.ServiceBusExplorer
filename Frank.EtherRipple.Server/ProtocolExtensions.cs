using System.Net;

namespace Frank.EtherRipple.Server;

public static class ProtocolExtensions
{
    public static string GetUrl(this IProtocol protocol, string path) => $"{protocol.Name.ToLower()}://{protocol.Address}:{protocol.Port}{path}";

    public static EndPoint GetEndPoint(this IProtocol protocol) => new IPEndPoint(protocol.Address, protocol.Port);
    
    public static IProtocol WithAddress(this IProtocol protocol, IPAddress address)
    {
        protocol.Address = address;
        return protocol;
    }
    
    public static IProtocol WithPort(this Protocol protocol, int port)
    {
        protocol.Port = port;
        return protocol;
    }
}