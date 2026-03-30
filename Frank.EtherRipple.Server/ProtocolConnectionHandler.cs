namespace Frank.EtherRipple.Server;

public delegate ValueTask ProtocolConnectionHandler(Stream stream, IProtocol protocol, CancellationToken cancellationToken);
