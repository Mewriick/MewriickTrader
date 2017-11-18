namespace MewriickTrader.Core.Analysis
{
    public class CandlePatternMatch
    {
        public bool Success { get; }

        public CandlePatternMatch(bool success)
        {
            Success = success;
        }

        public static CandlePatternMatch NoMatch
        {
            get { return new CandlePatternMatch(false); }
        }

        public static CandlePatternMatch Match
        {
            get { return new CandlePatternMatch(true); }
        }
    }
}
