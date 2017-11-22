using System;
using System.Collections.Generic;

namespace MewriickTrader.Core.Candle
{
    public class Candle : ValueObject, ICandle
    {
        public decimal Open { get; }

        public decimal Close { get; }

        public decimal High { get; }

        public decimal Low { get; }

        public DateTimeOffset DateTime { get; }

        public CandleBodyType BodyType
        {
            get
            {
                if (Open == Close)
                    return CandleBodyType.Neutral;

                if (Open < Close)
                    return CandleBodyType.Bullish;

                return CandleBodyType.Bearish;
            }
        }

        public Candle(decimal open, decimal high, decimal low, decimal close, DateTimeOffset dateTime)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            DateTime = dateTime;
        }

        public override string ToString()
        {
            return $"O: {Open}, H: {High}, L: {Low}, C: {Close} Body: {BodyType}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Open;
            yield return High;
            yield return Low;
            yield return Close;
            yield return BodyType;
            yield return DateTime;
        }
    }
}
