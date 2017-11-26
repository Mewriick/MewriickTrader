namespace MewriickTrader.Core.Trading.Market
{
    public interface IQuote
    {
        string Symbol { get; }

        decimal Bid { get; }

        decimal Ask { get; }
    }
}
