using MewriickTrader.Core.Candle;
using System;

namespace MewriickTrader.Core.Trading.Charts
{
    public interface IMarketTimerBars : IDisposable
    {
        IObservable<ICandle> TimeBarAdded { get; }

        ICandlesCollection TimeBars { get; }

        ICandle ListTimeBar { get; }

        string Symbol { get; }
    }
}
