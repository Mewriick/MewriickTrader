using MewriickTrader.Core.Candle;

namespace MewriickTrader.Core.Analysis
{
    public abstract class SingleCandlePatternBase : ICandlePatternable
    {
        public CandlePatternMatch Match(ICandlesCollection inputCandles, int index)
        {
            var candle = inputCandles[index];

            return Match(candle);
        }

        public abstract CandlePatternMatch Match(ICandle candle);
    }
}
