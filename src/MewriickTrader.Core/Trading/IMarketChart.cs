using MewriickTrader.Core.Candle;
using System;
using System.Collections.Generic;

namespace MewriickTrader.Core.Trading
{
    public interface IMarketChart
    {
        IObservable<ICandle> LastCandleAdded { get; }

        IList<ICandle> Candles { get; }

        ICandle LastCandle { get; }

        string Symbol { get; }
    }
}
