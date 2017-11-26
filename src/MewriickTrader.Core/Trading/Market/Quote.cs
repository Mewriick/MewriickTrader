using System.Collections.Generic;

namespace MewriickTrader.Core.Trading.Market
{
    public class Quote : ValueObject, IQuote
    {
        public string Symbol { get; }

        public decimal Bid { get; }

        public decimal Ask { get; }

        public Quote(string symbol, decimal bid, decimal ask)
        {
            Symbol = symbol;
            Bid = bid;
            Ask = ask;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Symbol;
            yield return Bid;
            yield return Ask;
        }

        public override string ToString()
        {
            return $"Symbol: {Symbol}, Bid: {Bid}, Ask: {Ask}";
        }
    }
}
