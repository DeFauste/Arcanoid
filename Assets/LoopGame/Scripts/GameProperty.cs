using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.LoopGame.Scripts
{
    public class GameProperty
    {
        public event Action<int> ScoreEvent;
        private int score = 0;
        public int Score { 
            get => score; 
            set
            {
                score += value;
                ScoreEvent?.Invoke(score);
            } 
        }
    }
}
