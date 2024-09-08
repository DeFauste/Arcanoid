using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.LoopGame.Scripts
{
    public class GameProperty
    {
        public event Action<int> ScoreEvent;
        public List<GameObject> cubs;
        public List<GameObject> ball;
        public int currentLvl = 1;
        
        public int Health { get; set; } = 3;

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
