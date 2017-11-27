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

        public DateTimeOffset OpenTime { get; }

        public DateTimeOffset CloseTime { get; }

        public Candle(decimal open, decimal high, decimal low, decimal close, DateTimeOffset openTime, DateTimeOffset closeTime)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            OpenTime = openTime;
            CloseTime = closeTime;
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
            yield return OpenTime;
            yield return CloseTime;
        }
    }
}
