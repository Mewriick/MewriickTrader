using MewriickTrader.Core.Candle;

namespace MewriickTrader.Core.Analysis
{
    public interface ICandlePatternable
    {
        CandlePatternMatch Match(ICandlesCollection inputCandles, int startIndex);
    }
}
