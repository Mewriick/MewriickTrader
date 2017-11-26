using System;

namespace MewriickTrader.Core.Trading.Market
{
    public interface IMarketListener : IDisposable
    {
        IObservable<IQuote> TimeBarUpdated { get; }
    }
}
