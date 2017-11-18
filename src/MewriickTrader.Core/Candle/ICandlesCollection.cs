using System.Collections.Generic;

namespace MewriickTrader.Core.Candle
{
    public interface ICandlesCollection : IList<ICandle>
    {
        decimal CurrentLow { get; }

        decimal CurrentHigh { get; }


        (int candleIndex, decimal value) HigherHigh(int startIndex, int endIndex);

        (int candleIndex, decimal value) HigherLow(int startIndex, int endIndex);

        (int candleIndex, decimal value) LowerHigh(int startIndex, int endIndex);

        (int candleIndex, decimal value) LowerLow(int startIndex, int endIndex);
    }
}
