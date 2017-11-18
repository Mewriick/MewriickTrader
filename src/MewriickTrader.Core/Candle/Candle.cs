using System;

namespace MewriickTrader.Core.Candle
{
    public class Candle : ICandle
    {
        public decimal Open { get; }

        public decimal Close { get; }

        public decimal High { get; }

        public decimal Low { get; }

        public DateTimeOffset DateTime { get; }

        public CandleType Type
        {
            get
            {
                if (Open < Close)
                    return CandleType.Bull;

                return CandleType.Bear;
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
            return $"O: {Open}, H: {High}, L: {Low}, C: {Close}";
        }
    }
}
