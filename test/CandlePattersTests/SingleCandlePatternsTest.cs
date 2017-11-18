using MewriickTrader.CandlestickPatterns.SingleCandlePatterns.Bullish;
using MewriickTrader.CandlestickPatterns.SingleCandlePatterns.Neutral;
using MewriickTrader.Core.Candle;
using System;
using Xunit;

namespace CandlePattersTests
{
    public class SingleCandlePatternsTest
    {

        public static TheoryData<Candle> HammerData = new TheoryData<Candle>
        {
            { new Candle(1.17955m, 1.17959m, 1.17939m, 1.17957m, DateTime.Now) },
            { new Candle(1.17943m, 1.17946m, 1.17934m, 1.17946m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_IsHammer_Tests))]
        [MemberData(nameof(HammerData))]
        public void Candle_IsHammer_Tests(ICandle candle)
        {
            var hammerPattern = new Hammer();

            var match = hammerPattern.Match(candle);

            Assert.True(match.Success, $"This candle {candle.ToString()} is Hammer");
        }

        public static TheoryData<Candle> DojiData = new TheoryData<Candle>
        {
            { new Candle(1.17937m, 1.17942m, 1.17932m, 1.17937m, DateTime.Now) },
            { new Candle(1.17917m, 1.17924m, 1.17911m, 1.17918m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_IsDoji_Tests))]
        [MemberData(nameof(DojiData))]
        public void Candle_IsDoji_Tests(ICandle candle)
        {
            var dojiPattern = new Doji();

            var match = dojiPattern.Match(candle);

            Assert.True(match.Success, $"This candle {candle.ToString()} is Doji");
        }

        public static TheoryData<Candle> NoDojiData = new TheoryData<Candle>
        {
            { new Candle(1.17955m, 1.17959m, 1.17939m, 1.17957m, DateTime.Now) },
            { new Candle(1.17910m, 1.17926m, 1.17900m, 1.17926m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_Is_Not_Doji_Tests))]
        [MemberData(nameof(NoDojiData))]
        public void Candle_Is_Not_Doji_Tests(ICandle candle)
        {
            var dojiPattern = new Doji();

            var match = dojiPattern.Match(candle);

            Assert.False(match.Success, $"This candle {candle.ToString()} is NOT Doji");
        }
    }
}
