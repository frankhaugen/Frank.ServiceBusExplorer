using System.Collections.Concurrent;
using System.Net;

namespace Frank.EtherRipple.Server;

public sealed class RippleServer
{
    private readonly ConcurrentBag<RippleRoute> _routes = new();

    public RippleServer Map(IProtocol protocol, ProtocolConnectionHandler handler)
    {
        ArgumentNullException.ThrowIfNull(protocol);
        ArgumentNullException.ThrowIfNull(handler);
        _routes.Add(new RippleRoute(protocol, handler));
        return this;
    }

    public IEnumerable<RippleRoute> Routes => _routes.ToArray();

    public IEnumerable<EndPoint> Endpoints => Routes.Select(r => r.Endpoint);

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var routeList = Routes.ToList();
        if (routeList.Count == 0)
            throw new InvalidOperationException("Map at least one protocol and handler before RunAsync.");

        var listeners = routeList.Select(r => new ProtocolListener(r.Protocol, r.Handler)).ToList();
        await Task.WhenAll(listeners.Select(l => l.ListenAsync(cancellationToken))).ConfigureAwait(false);
    }
}
