using System.Collections.Generic;

namespace MewriickTrader.Core.Analysis.Indicators
{
    public class MovingAverageParams : ValueObject
    {
        public string Symbol { get; }

        public int TimeFrameType { get; }

        public int Period { get; }

        public int AppliedPriceType { get; }

        public int Shift { get; }

        public int AvereageMethodType { get; }

        public int MovingAvereageShift { get; }

        public MovingAverageParams(string symbol, int timeFrameType, int period, int avereageMethodType, int appliedPriceType, int movingAvereageShift, int shitf)
        {
            Symbol = symbol;
            TimeFrameType = timeFrameType;
            Period = period;
            AppliedPriceType = appliedPriceType;
            AvereageMethodType = avereageMethodType;
            MovingAvereageShift = movingAvereageShift;
            Shift = shitf;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Symbol;
            yield return TimeFrameType;
            yield return Period;
            yield return AppliedPriceType;
            yield return AvereageMethodType;
            yield return MovingAvereageShift;
            yield return Shift;
        }
    }
}
