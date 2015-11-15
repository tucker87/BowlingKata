using BowlingKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingTest
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
        public void RollOneThenOneScoreTwo()
        {
            RollMany(2, 1);
            Assert.AreEqual(2, _game.Score);
        }

        [TestMethod]
        public void RollTwentyOnesScoreTwenty()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void RollSpareThenOneScoreTwelve()
        {
            RollSpare();
            _game.Roll(1);
            Assert.AreEqual(12, _game.Score);
        }

        [TestMethod]
        public void RollSpareThenTwoScoreFourteen()
        {
            RollSpare();
            _game.Roll(2);
            Assert.AreEqual(14, _game.Score);
        }

        [TestMethod]
        public void RollSpareRollTwoRollOneScoreFifteen()
        {
            RollSpare();
            _game.Roll(2);
            _game.Roll(1);
            Assert.AreEqual(15, _game.Score);
        }

        [TestMethod]
        public void RollOneRollOneRollSpareRollOneScoreFourteen()
        {
            RollMany(2, 1);
            RollSpare();
            _game.Roll(1);
            Assert.AreEqual(14, _game.Score);
        }

        [TestMethod]
        public void RollOneRollOneRollSpareRollTwoScoreSixteen()
        {
            RollMany(2, 1);
            RollSpare();
            _game.Roll(2);
            Assert.AreEqual(16, _game.Score);
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
        public void RollAllStrikes()
        {
            RollMany(11, 10);
            Assert.AreEqual(300, _game.Score);
        }

        private void RollSpare()
        {
            RollMany(2, 5);
        }

        private void RollMany(int rolls, int pins)
        {
            for (var i = 0; i < rolls; i++)
                _game.Roll(pins);
        }
    }
}
