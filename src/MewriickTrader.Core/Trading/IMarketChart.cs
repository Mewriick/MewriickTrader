using MewriickTrader.Core.Candle;
using System.Collections.Generic;

namespace MewriickTrader.Core.Trading
{
    public interface IMarketChart
    {
        IList<ICandle> Candles { get; }

        ICandle LastCandle { get; }

        string Symbol { get; }
    }
}
