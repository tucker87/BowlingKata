namespace BowlingKata2
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _rollIndex;

        public void Roll(int pins)
        {
            _rolls[_rollIndex] = pins;
            _rollIndex += IsStrike(_rollIndex) ? 2 : 1;
        }

        public int Score
        {
            get
            {
                var score = 0;
                for (var currentFrame = 0; currentFrame < 20; currentFrame += 2)
                {
                    if (IsStrike(currentFrame))
                        score += GetNextTwoRolls(currentFrame);

                    if (IsSpare(currentFrame))
                        score += GetNextRoll(currentFrame);

                    score += GetCurrentFrameRolls(currentFrame);
                }
                return score;
            }
        }

        private bool IsStrike(int roll)
        {
            return _rolls[roll] == 10;
        }

        private bool IsSpare(int roll)
        {
            return GetCurrentFrameRolls(roll) == 10;
        }

        private int GetNextTwoRolls(int roll)
        {
            return _rolls[roll + 1] + _rolls[roll + 2];
        }

        private int GetCurrentFrameRolls(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1];
        }

        private int GetNextRoll(int roll)
        {
            return _rolls[roll + 2];
        }
    }
}