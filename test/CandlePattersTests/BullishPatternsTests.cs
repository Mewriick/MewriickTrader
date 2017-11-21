using CandlePattersTests.Mocks;
using MewriickTrader.CandlestickPatterns.Bullish;
using System;
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
        public void UpTrend_Wrong_Period_Throws_ArgumentException()
        {
            var context = new TestCandlesContext()
                                .WithCandleIndex(3);

            var upTrendPattern = new UpTrend();
            Assert.Throws<ArgumentException>(() => upTrendPattern.Match(context));
        }

        [Fact]
        public void UpTrend_Wrong_CandleIndex_Throws_ArgumentException()
        {
            var context = new TestCandlesContext()
                                .WithUpTrend()
                                .WithCandleIndex(2);

            var upTrendPattern = new UpTrend();
            Assert.Throws<ArgumentException>(() => upTrendPattern.Match(context));
        }
    }
}
