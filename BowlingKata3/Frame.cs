using System.Collections.Generic;
using System.Linq;

namespace BowlingKata3
{
    public class Frame
    {
        public bool IsFull => _rolls[0] == 10 || _rolls.All(x => x != null);
        public int Score => (_rolls.Sum() ?? 0) + CalculateBonus();
        private readonly int?[] _rolls;
        private readonly Frame[] _frames;
        private readonly int _index;

        public Frame(Frame[] frames, int index)
        {
            _rolls = new int?[2];
            _frames = frames;
            _index = index;
        }

        public int CalculateBonus()
        {
            if (IsStrike())
                return GetNextTwoRolls().Sum();

            if (IsSpare())
                return GetNextFramesFirstRoll();

            return 0;
        }

        public void Roll(int pins)
        {
            if (_rolls[0] == null)
                _rolls[0] = pins;
            else
                _rolls[1] = pins;
        }

        private bool IsStrike()
        {
            return _rolls[0] == 10;
        }

        private bool IsSpare()
        {
            return _rolls.Sum() == 10;
        }

        private int GetNextFramesFirstRoll()
        {
            return _frames[_index + 1]._rolls[0] ?? 0;
        }

        private IEnumerable<int> GetNextTwoRolls()
        {
            return _frames.Skip(_index + 1)
                .SelectMany(x => x._rolls)
                .Where(x => x != null)
                .Select(x => (int)x)
                .Take(2);
        }
    }
}