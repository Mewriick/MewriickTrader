using System;

namespace MewriickTrader.Core.Candle
{
    public interface ITick
    {
        DateTimeOffset DateTime { get; }
    }
}
