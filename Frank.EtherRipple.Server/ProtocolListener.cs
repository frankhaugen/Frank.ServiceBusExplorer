using System.Net;
using System.Net.Sockets;

namespace Frank.EtherRipple.Server;

public class ProtocolListener : IProtocolListener
{
    private readonly IProtocol _protocol;
    private readonly ProtocolConnectionHandler _handler;

    public ProtocolListener(IProtocol protocol, ProtocolConnectionHandler handler)
    {
        _protocol = protocol ?? throw new ArgumentNullException(nameof(protocol));
        _handler = handler ?? throw new ArgumentNullException(nameof(handler));
    }

    public EndPoint EndPoint => _protocol.GetEndPoint();

    public async Task ListenAsync(CancellationToken cancellationToken)
    {
        if (_protocol.GetEndPoint() is not IPEndPoint ipe)
            throw new NotSupportedException("Only IPEndPoint bindings are supported.");

        var listener = new TcpListener(ipe.Address, ipe.Port);
        listener.Start();

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                TcpClient client;
                try
                {
                    client = await listener.AcceptTcpClientAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (ObjectDisposedException)
                {
                    break;
                }

                _ = HandleClientAsync(client, cancellationToken);
            }
        }
        finally
        {
            listener.Stop();
        }
    }

    private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
    {
        try
        {
            using var stream = client.GetStream();
            await _handler(stream, _protocol, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            // shutdown
        }
        catch (IOException)
        {
            // client reset
        }
        finally
        {
            client.Dispose();
        }
    }
}

public interface IProtocolListener
{
    EndPoint EndPoint { get; }
    Task ListenAsync(CancellationToken cancellationToken);
}
