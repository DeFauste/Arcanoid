using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.LoopGame.Scripts
{
    public class GameProperty
    {
        public event Action<int> ScoreEvent;
        public List<GameObject> cubs;
        public int currentLvl = 1;

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
