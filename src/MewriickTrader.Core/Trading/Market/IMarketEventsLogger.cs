using MewriickTrader.Core.Candle;
using System;

namespace MewriickTrader.Core.Trading.Market
{
    public interface IMarketEventsLogger : IDisposable
    {
        void OnTimeBarAdded(ICandle timeBar);

        void OnTimeBarUpdated(IQuote quoteUpdated);

        void StartLogging();
    }
}
