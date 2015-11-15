using System.Collections.Generic;
using System.Linq;

/*
First iteration. Started out TDD then took over with my own design when I thought
it needed more classes. Got out of hand. Not entirely happy with result.
*/
namespace BowlingKata
{
    public class Game
    {
        public Game()
        {
            _frames.Add(new Frame(0, _frames));
        }

        public int Score => _frames.Sum(frame => frame.Score);
        private readonly List<Frame> _frames = new List<Frame> ();
        private int _frameIndex;
        private Frame CurrentFrame => _frames[_frameIndex];


        public void Roll(int i)
        {
            CurrentFrame.AddRoll(i);

            if (CurrentFrame.Rolls[1] != null || i == 10)
            {
                _frameIndex++;
                _frames.Add(new Frame(_frameIndex, _frames));
            }
        }
    }

    public class Frame
    {
        public Frame(int frameIndex, List<Frame> frames)
        {
            Index = frameIndex;
            Frames = frames;
        }

        internal readonly List<Frame> Frames;
        public int Index { get; set; }
        public int?[] Rolls = {null, null};

        public int RollTotal => (Rolls[0] ?? 0) + (Rolls[1] ?? 0);

        public int Bonus
        {
            get
            {
                var score = 0;
                var nextFrame = Index + 1;
                if (Rolls[0] == 10)
                {
                    var rollCount = 0;
                    while (rollCount < 2 && nextFrame < Frames.Count - 1)
                    {
                        foreach (var roll in Frames[nextFrame].Rolls)
                        {
                            if (roll > 0)
                            {
                                score += (int) roll;
                                rollCount++;
                            }
                        }
                        nextFrame++;
                    }
                }

                if (Rolls[0] + Rolls[1] == 10)
                    if (Frames.Count > Index + 1)
                        score = Frames[Index + 1].Rolls[0] ?? 0;

                return score;
            }
        }

        public int Score => RollTotal + Bonus;

        private int _rollIndex;
        public void AddRoll(int i)
        {
            Rolls[_rollIndex] = i;
            _rollIndex++;
        }
    }
}