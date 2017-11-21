using System;

namespace MewriickTrader.Core.Candle
{
    public static class ICandleExtensions
    {
        public static decimal UpperShadow(this ICandle candle)
        {
            var bodyMaximum = Math.Max(candle.Close, candle.Open);

            return candle.High - bodyMaximum;
        }

        public static decimal LowerShadow(this ICandle candle)
        {
            var bodyMinimum = Math.Min(candle.Close, candle.Open);

            return bodyMinimum - candle.Low;
        }

        public static decimal RealBody(this ICandle candle)
        {
            return Math.Abs(candle.Open - candle.Close);
        }

        public static decimal SizeFromHighToLow(this ICandle candle)
        {
            return candle.High - candle.Low;
        }

        public static decimal MeanOpenClose(this ICandle candle)
        {
            return (candle.Open + candle.Close) / 2;
        }

        public static bool IsBullish(this ICandle candle)
        {
            return candle.BodyType == CandleBodyType.Bullish;
        }

        public static bool IsBearish(this ICandle candle)
        {
            return candle.BodyType == CandleBodyType.Bearish;
        }
    }
}
