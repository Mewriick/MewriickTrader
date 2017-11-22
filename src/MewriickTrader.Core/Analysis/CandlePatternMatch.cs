using System.Collections.Generic;

namespace MewriickTrader.Core.Analysis
{
    public class CandlePatternMatch : ValueObject
    {
        public bool Success { get; }

        public bool PatternNeedConfirmation { get; }

        public CandlePatternMatch(bool success, bool patternNeedConfirmation)
        {
            Success = success;
            PatternNeedConfirmation = patternNeedConfirmation;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Success;
        }

        public static CandlePatternMatch NoMatch
        {
            get { return new CandlePatternMatch(false, false); }
        }

        public static CandlePatternMatch MatchWithoutConfirmationNeeded
        {
            get { return new CandlePatternMatch(true, false); }
        }

    }
}
