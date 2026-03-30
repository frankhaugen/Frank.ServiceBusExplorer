namespace Frank.EtherRipple.Server;

public class FtpProtocol : Protocol
{
    public override string Name => "FTP";
    public override int Port { get; set; } = 21; // Default FTP port
}