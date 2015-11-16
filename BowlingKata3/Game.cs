using System.Linq;

namespace BowlingKata3
{
    public class Game
    {
        public int Score => _frames.Select(x => x.Score).Sum();
        private readonly Frame[] _frames;

        public Game()
        {
            _frames = new Frame[11];
            for (var i = 0; i < _frames.Length; i++) 
                _frames[i] = new Frame(_frames, i);
        }

        public void Roll(int pins)
        {
            _frames.First(x => !x.IsFull).Roll(pins);
        }
    }
}