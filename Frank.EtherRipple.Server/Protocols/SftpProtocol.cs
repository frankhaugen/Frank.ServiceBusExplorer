using System.Net;

namespace Frank.EtherRipple.Server;

public class SftpProtocol : Protocol
{
    public override string Name => "SFTP";
    public override int Port { get; set; } = 22; // Default SFTP port
}