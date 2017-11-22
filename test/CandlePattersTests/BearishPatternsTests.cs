using CandlePattersTests.Mocks;
using MewriickTrader.Analysis.CandlestickPatterns.Bearish;
using System;
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
        public void DownTrend_Wrong_Period_Throws_ArgumentException()
        {
            var context = new TestCandlesContext()
                                .WithCandleIndex(3);

            var downTrendPattern = new DownTrend();
            Assert.Throws<ArgumentException>(() => downTrendPattern.Match(context));
        }

        [Fact]
        public void DownTrend_Wrong_CandleIndex_Throws_ArgumentException()
        {
            var context = new TestCandlesContext()
                                .WithDownTrend()
                                .WithCandleIndex(2);

            var downTrendPattern = new DownTrend();
            Assert.Throws<ArgumentException>(() => downTrendPattern.Match(context));
        }
    }
}
