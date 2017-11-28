using System.Collections.Generic;

namespace MewriickTrader.Core.Indicators
{
    public class RSIIndicatorParams : ValueObject
    {
        public string Symbol { get; }

        public int TimeFrameType { get; }

        public int Period { get; }

        public int AppliedPriceType { get; }

        public int Shift { get; }

        public RSIIndicatorParams(string symbol, int timeFrameType, int period, int appliedPriceType, int shitf)
        {
            Symbol = symbol;
            TimeFrameType = timeFrameType;
            Period = period;
            AppliedPriceType = appliedPriceType;
            Shift = shitf;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Symbol;
            yield return TimeFrameType;
            yield return Period;
            yield return AppliedPriceType;
            yield return Shift;
        }
    }
}
