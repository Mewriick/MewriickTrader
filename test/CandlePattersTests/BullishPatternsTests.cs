using CandlePattersTests.Mocks;
using MewriickTrader.Analysis.CandlestickPatterns.Bearish;
using MewriickTrader.Analysis.CandlestickPatterns.Bullish;
using System.Collections.Generic;
using Xunit;

namespace CandlePattersTests
{
    public class BullishPatternsTests
    {
        [Fact]
        public void Is_UpTrend_Test()
        {
            var context = new TestCandlesContext()
                                .WithUpTrend()
                                .WithCandleIndex(3);

            var upTrendPattern = new UpTrend();
            var match = upTrendPattern.Match(context);

            Assert.True(match.Success, "Candles create an UpTrend pattern");
        }

        [Fact]
        public void UpTrend_Wrong_Period_Return_False()
        {
            var context = new TestCandlesContext()
                                .WithCandleIndex(3);

            var upTrendPattern = new UpTrend();
            var match = upTrendPattern.Match(context);

            Assert.False(match.Success);
        }

        [Fact]
        public void UpTrend_Wrong_CandleIndex_Return_False()
        {
            var context = new TestCandlesContext()
                                .WithUpTrend()
                                .WithCandleIndex(2);

            var upTrendPattern = new UpTrend();
            var match = upTrendPattern.Match(context);

            Assert.False(match.Success);
        }

        [Fact]
        public void Is_Hammer_Test()
        {
            var context = new TestCandlesContext()
                                .WithHammers()
                                .WithCandleIndex(4);

            var downTrend = new DownTrend();
            var hammerPattern = new Hammer(downTrend);

            var match = hammerPattern.Match(context);

            Assert.True(match.Success, "Candles create an Hammer pattern");
        }

        [Theory, MemberData(nameof(NotHammerContexts))]
        public void Is_Not_Hammer_Test(TestCandlesContext context)
        {
            var downTrend = new DownTrend();
            var hammerPattern = new Hammer(downTrend);

            var match = hammerPattern.Match(context);

            Assert.False(match.Success, "Candles do not create an Hammer pattern");
        }

        public static IEnumerable<object[]> NotHammerContexts
        {
            get
            {
                return new[]
                {
                    new object[] {new TestCandlesContext().WithDownTrend().WithBullishDragonFlyDoji().WithCandleIndex(4) },
                    new object[] {new TestCandlesContext().WithDownTrend().WithBigBullishCandle().WithCandleIndex(4) },
                    new object[] {new TestCandlesContext().WithBasicCandles().WithCandleIndex(0) },
                };
            }
        }
    }
}
