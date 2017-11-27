using MewriickTrader.Core.Candle;
using System;
using System.Collections.Generic;
using Xunit;

namespace CoreTest
{
    public class ValueObjectTest
    {
        [Fact]
        public void Two_Candles_Are_Equal()
        {
            var candleOne = new Candle(10m, 15m, 5m, 8m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1));
            var candleTwo = new Candle(10m, 15m, 5m, 8m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1));

            var equals = candleOne == candleTwo;

            Assert.True(equals);
        }

        [Theory, MemberData(nameof(CandleData))]
        public void Two_Candles_Are_Not_Equal(Candle candleTwo)
        {
            var candleOne = new Candle(11m, 15m, 5m, 8m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1));

            var equals = candleOne == candleTwo;

            Assert.False(equals, $"SecondCandle {candleTwo}");
        }

        [Fact]
        public void Two_Candles_Have_Same_HashCode()
        {
            var candleOne = new Candle(10m, 15m, 5m, 8m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1));
            var candleTwo = new Candle(10m, 15m, 5m, 8m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1));

            var equals = candleOne.GetHashCode() == candleTwo.GetHashCode();

            Assert.True(equals);
        }

        [Theory, MemberData(nameof(CandleData))]
        public void Two_Candles_Do_Not_Have_Same_HashCode(Candle candleTwo)
        {
            var candleOne = new Candle(11m, 15m, 5m, 8m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1));

            var equals = candleOne == candleTwo;

            Assert.False(equals, $"SecondCandle {candleTwo}");
        }

        public static IEnumerable<object[]> CandleData
        {
            get
            {
                return new[]
                {
                    new object[] { new Candle(10m, 15m, 5m, 8m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1)) },
                    new object[] { new Candle(11m, 14m, 5m, 8m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1)) },
                    new object[] { new Candle(11m, 15m, 6m, 8m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1)) },
                    new object[] { new Candle(11m, 15m, 5m, 7m, new DateTime(2017, 12, 1), new DateTime(2017, 11, 1)) },
                    new object[] { new Candle(11m, 15m, 5m, 8m, new DateTime(2016, 12, 1), new DateTime(2017, 11, 1)) },
                    new object[] { new Candle(11m, 15m, 5m, 8m, new DateTime(2017, 12, 1), new DateTime(2016, 11, 1)) }
                };
            }
        }
    }
}

