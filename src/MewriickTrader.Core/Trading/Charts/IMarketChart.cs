using MewriickTrader.Core.Candle;
using System;

namespace MewriickTrader.Core.Trading.Charts
{
    public interface IMarketChart : IDisposable
    {
        IObservable<ICandle> TimeBarAdded { get; }

        ICandlesCollection Candles { get; }

        ICandle LastCandle { get; }

        string Symbol { get; }
    }
}
