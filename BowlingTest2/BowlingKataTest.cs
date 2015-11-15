using BowlingKata2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingTest2
{
    [TestClass]
    public class BowlingKataTest
    {
        private Game _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new Game();
        }

        [TestMethod]
        public void RollOneScoreOne()
        {
            _game.Roll(1);
            Assert.AreEqual(1, _game.Score);
        }

        [TestMethod]
        public void RollTwoScoreTwo()
        {
            _game.Roll(2);
            Assert.AreEqual(2, _game.Score);
        }

        [TestMethod]
        public void RollOneRollOneScoreTwo()
        {
            RollMany(2, 1);
            Assert.AreEqual(2, _game.Score);
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
            _game.Roll(1);
            RollMany(2, 1);
            Assert.AreEqual(15, _game.Score);
        }

        [TestMethod]
        public void RollStrikeRollOneRollOneScoreFourteen()
        {
            _game.Roll(10);
            _game.Roll(1);
            _game.Roll(1);
            Assert.AreEqual(14, _game.Score);
        }

        [TestMethod]
        public void RollAllOnesScoreTwenty()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void RollAllStrikesScoreThreeHundred()
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
