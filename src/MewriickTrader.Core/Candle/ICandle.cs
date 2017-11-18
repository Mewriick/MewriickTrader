namespace MewriickTrader.Core.Candle
{
    public interface ICandle : ITick
    {
        decimal Open { get; }

        decimal Close { get; }

        decimal High { get; }

        decimal Low { get; }
    }
}
