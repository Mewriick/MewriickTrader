namespace CandlePattersTests
{
    public class SingleCandlePatternsTest
    {
        /*
        public static TheoryData<Candle> HammerData = new TheoryData<Candle>
        {
            { new Candle(1.17955m, 1.17959m, 1.17939m, 1.17957m, DateTime.Now) },
            { new Candle(1.17943m, 1.17946m, 1.17934m, 1.17946m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_Is_Hammer_Tests))]
        [MemberData(nameof(HammerData))]
        public void Candle_Is_Hammer_Tests(ICandle candle)
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

        [Theory(DisplayName = nameof(Candle_Is_Doji_Tests))]
        [MemberData(nameof(DojiData))]
        public void Candle_Is_Doji_Tests(ICandle candle)
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

        public static TheoryData<Candle> DragonFlyDojiData = new TheoryData<Candle>
        {
            { new Candle(1.17972m, 1.17973m, 1.17964m, 1.17972m, DateTime.Now) },
            { new Candle(1.17947m, 1.17947m, 1.17945m, 1.17947m, DateTime.Now) },
            { new Candle(1.17943m, 1.17944m, 1.17938m, 1.17943m, DateTime.Now) },
            { new Candle(1.17923m, 1.17926m, 1.17910m, 1.17924m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_Is_BullishDragonFlyDoji_Tests))]
        [MemberData(nameof(DragonFlyDojiData))]
        public void Candle_Is_BullishDragonFlyDoji_Tests(ICandle candle)
        {
            var dojiPattern = new Doji();
            var dragonFlyDojiPattern = new BullishDragonFlyDoji(dojiPattern);

            var match = dragonFlyDojiPattern.Match(candle);

            Assert.True(match.Success, $"This candle {candle.ToString()} is BullishDragonFlyDoji");
        }

        public static TheoryData<Candle> NoDragonFlyDojiData = new TheoryData<Candle>
        {
            { new Candle(1.17920m, 1.17921m, 1.17904m, 1.17918m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_Is_Not_BullishDragonFlyDoji_Tests))]
        [MemberData(nameof(NoDragonFlyDojiData))]
        public void Candle_Is_Not_BullishDragonFlyDoji_Tests(ICandle candle)
        {
            var dojiPattern = new Doji();
            var dragonFlyDojiPattern = new BullishDragonFlyDoji(dojiPattern);

            var match = dragonFlyDojiPattern.Match(candle);

            Assert.False(match.Success, $"This candle {candle.ToString()} is NOT BullishDragonFlyDoji");
        }

        public static TheoryData<Candle> BearihsSpinningTop = new TheoryData<Candle>
        {
            { new Candle(1.17922m, 1.17925m, 1.17917m, 1.17921m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_Is_BearishSpiningTop_Tests))]
        [MemberData(nameof(BearihsSpinningTop))]
        public void Candle_Is_BearishSpiningTop_Tests(ICandle candle)
        {
            var bearishSpinningTop = new BearishSpiningTop();

            var match = bearishSpinningTop.Match(candle);

            Assert.True(match.Success, $"This candle {candle.ToString()} is {nameof(BearishSpiningTop)}");
        }


        public static TheoryData<Candle> NoBearihsSpinningTop = new TheoryData<Candle>
        {
            { new Candle(1.17972m, 1.17973m, 1.17964m, 1.17972m, DateTime.Now) },
            { new Candle(1.17955m, 1.17959m, 1.17939m, 1.17957m, DateTime.Now) },
            { new Candle(1.17918m, 1.17924m, 1.17912m, 1.17919m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_Is_Not_BearishSpiningTop_Tests))]
        [MemberData(nameof(NoBearihsSpinningTop))]
        public void Candle_Is_Not_BearishSpiningTop_Tests(ICandle candle)
        {
            var bearishSpinningTop = new BearishSpiningTop();

            var match = bearishSpinningTop.Match(candle);

            Assert.False(match.Success, $"This candle {candle.ToString()} is NOT {nameof(BearishSpiningTop)}");
        }

        public static TheoryData<Candle> BullishSpinningTop = new TheoryData<Candle>
        {
            { new Candle(1.17918m, 1.17924m, 1.17912m, 1.17919m, DateTime.Now) },
            { new Candle(1.17933m, 1.17941m, 1.17927m, 1.17934m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_Is_BullishSpiningTop_Tests))]
        [MemberData(nameof(BullishSpinningTop))]
        public void Candle_Is_BullishSpiningTop_Tests(ICandle candle)
        {
            var bullishSpinningTop = new BullishSpinningTop();

            var match = bullishSpinningTop.Match(candle);

            Assert.True(match.Success, $"This candle {candle.ToString()} is {nameof(BullishSpinningTop)}");
        }

        public static TheoryData<Candle> NotBullishSpinningTop = new TheoryData<Candle>
        {
            { new Candle(1.17922m, 1.17925m, 1.17917m, 1.17921m, DateTime.Now) },
            { new Candle(1.17908m, 1.17929m, 1.17906m, 1.17925m, DateTime.Now) },
        };

        [Theory(DisplayName = nameof(Candle_Is_Not_BullishSpiningTop_Tests))]
        [MemberData(nameof(NotBullishSpinningTop))]
        public void Candle_Is_Not_BullishSpiningTop_Tests(ICandle candle)
        {
            var bullishSpinningTop = new BullishSpinningTop();

            var match = bullishSpinningTop.Match(candle);

            Assert.False(match.Success, $"This candle {candle.ToString()} is NOT {nameof(BullishSpinningTop)}");
        }*/
    }
}
