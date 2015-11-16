using BowlingKata3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingTest3
{
    [TestClass]
    public class BowlingTests
    {
        private Game _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new Game();
        }

        [TestMethod]
        public void RollZeroScoreZero()
        {
            _game.Roll(0);
            Assert.AreEqual(0, _game.Score);
        }

        [TestMethod]
        public void RollOneScoreOne()
        {
            _game.Roll(1);
            Assert.AreEqual(1, _game.Score);
        }

        [TestMethod]
        public void RollOneRollOneScoreTwo()
        {
            RollMany(2, 1);
            Assert.AreEqual(2, _game.Score);
        }

        [TestMethod]
        public void RollAllZerosScoreZero()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, _game.Score);
        }

        [TestMethod]
        public void RollAllOnesScoreTwenty()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void RollSpareRoll1ScoreTwelve()
        {
            RollMany(2, 5);
            _game.Roll(1);
            Assert.AreEqual(12, _game.Score);
        }

        [TestMethod]
        public void RollOneRollOneRollSpareRollOneRollOneScoreFifteen()
        {
            RollMany(2, 1);
            _game.Roll(9);
            RollMany(3, 1);
            Assert.AreEqual(15, _game.Score);
        }

        [TestMethod]
        public void RollStrikeRollOneRollTwoScoreSixteen()
        {
            _game.Roll(10);
            _game.Roll(1);
            _game.Roll(2);
            Assert.AreEqual(16, _game.Score);
        }

        [TestMethod]
        public void RollPerfectGameScoreThreeHundred()
        {
            RollMany(11, 10);
            Assert.AreEqual(300, _game.Score);
        }
        
        private void RollMany(int rolls, int pins)
        {
            for (var i = 0; i < rolls; i++)
                _game.Roll(pins);
        }
    }
}