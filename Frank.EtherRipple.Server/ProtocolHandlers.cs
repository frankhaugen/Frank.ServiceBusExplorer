using System.Text;

namespace Frank.EtherRipple.Server;

public static class ProtocolHandlers
{
    public static async ValueTask EchoAsync(Stream stream, IProtocol _, CancellationToken cancellationToken)
    {
        var buffer = new byte[8192];
        int read;
        while ((read = await stream.ReadAsync(buffer.AsMemory(0, buffer.Length), cancellationToken).ConfigureAwait(false)) > 0)
            await stream.WriteAsync(buffer.AsMemory(0, read), cancellationToken).ConfigureAwait(false);
    }

    public static async ValueTask MinimalHttpHtmlAsync(Stream stream, IProtocol _, CancellationToken cancellationToken)
    {
        var buffer = new byte[8192];
        await stream.ReadAsync(buffer.AsMemory(0, buffer.Length), cancellationToken).ConfigureAwait(false);
        var body = Encoding.UTF8.GetBytes("<html><body><h1>Hello World</h1></body></html>");
        await stream.WriteAsync(body, cancellationToken).ConfigureAwait(false);
    }
}
