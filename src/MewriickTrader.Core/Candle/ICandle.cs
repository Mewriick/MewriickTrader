using System;

namespace MewriickTrader.Core.Candle
{
    public interface ICandle
    {
        decimal Open { get; }

        decimal Close { get; }

        decimal High { get; }

        decimal Low { get; }

        CandleBodyType BodyType { get; }

        DateTimeOffset OpenTime { get; }

        DateTimeOffset CloseTime { get; }
    }
}
