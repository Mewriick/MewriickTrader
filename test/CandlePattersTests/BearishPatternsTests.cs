using CandlePattersTests.Mocks;
using MewriickTrader.Analysis.CandlestickPatterns.Bearish;
using MewriickTrader.Analysis.CandlestickPatterns.Bullish;
using System.Collections.Generic;
using Xunit;

namespace CandlePattersTests
{
    public class BearishPatternsTests
    {
        [Fact]
        public void Is_DownTrend_Test()
        {
            var context = new TestCandlesContext()
                                .WithDownTrend()
                                .WithCandleIndex(3);

            var downTrendPattern = new DownTrend();
            var match = downTrendPattern.Match(context);

            Assert.True(match.Success, "Candles create an DownTrend pattern");
        }

        [Fact]
        public void DownTrend_Wrong_Period_Return_False()
        {
            var context = new TestCandlesContext()
                                .WithCandleIndex(3);

            var downTrendPattern = new DownTrend();
            var match = downTrendPattern.Match(context);

            Assert.False(match.Success);
        }

        [Fact]
        public void DownTrend_Wrong_CandleIndex_Return_False()
        {
            var context = new TestCandlesContext()
                                .WithDownTrend()
                                .WithCandleIndex(2);

            var downTrendPattern = new DownTrend();
            var match = downTrendPattern.Match(context);

            Assert.False(match.Success);
        }

        [Fact]
        public void Is_HangingMan_Test()
        {
            var context = new TestCandlesContext()
                                .WithUpTrend()
                                .WithPinBar()
                                .WithCandleIndex(4);

            var upTrend = new UpTrend();
            var hangingManPattern = new HangingMan(upTrend);

            var match = hangingManPattern.Match(context);

            Assert.True(match.Success, "Candles create an Hammer pattern");
        }

        [Theory, MemberData(nameof(NotHangingManContexts))]
        public void Is_Not_HangingMan_Test(TestCandlesContext context)
        {
            var upTrend = new UpTrend();
            var hangingManPattern = new HangingMan(upTrend);

            var match = hangingManPattern.Match(context);

            Assert.False(match.Success, "Candles do not create an Hammer pattern");
        }

        public static IEnumerable<object[]> NotHangingManContexts
        {
            get
            {
                return new[]
                {
                    new object[] {new TestCandlesContext().WithUpTrend().WithBullishDragonFlyDoji().WithCandleIndex(4) },
                    new object[] {new TestCandlesContext().WithUpTrend().WithBigBullishCandle().WithCandleIndex(4) },
                    new object[] {new TestCandlesContext().WithBasicCandles().WithCandleIndex(0) },
                };
            }
        }
    }
}
