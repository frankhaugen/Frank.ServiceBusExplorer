using System.Net;

namespace Frank.EtherRipple.Server;

public static class ProtocolFactory
{
    public static IProtocol Create(string name, int port, IPAddress? address = null)
    {
        var addr = address ?? IPAddress.Any;
        return name.Trim().ToUpperInvariant() switch
        {
            "HTTP" => new HttpProtocol { Port = port, Address = addr },
            "HTTPS" => new HttpsProtocol { Port = port, Address = addr },
            "FTP" => new FtpProtocol { Port = port, Address = addr },
            "FTPS" => new FtpsProtocol { Port = port, Address = addr },
            "IRC" => new IrcProtocol { Port = port, Address = addr },
            "IRCS" => new IrcsProtocol { Port = port, Address = addr },
            "SFTP" => new SftpProtocol { Port = port, Address = addr },
            _ => new CustomProtocol(name, port, addr),
        };
    }
}
