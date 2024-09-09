using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.LoopGame.Scripts
{
    public class GameProperty
    {
        public event Action<int> ScoreEvent;
        public event Action<int> BallDeleteEvent;
        public List<GameObject> cubs;
        public int currentLvl = 1;
        public int speedBall = 5;
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
        private List<GameObject> ball = new();
        public void AddBall(GameObject gameObject)
        {
            ball.Add(gameObject);
        }
        public void RemoveBall(GameObject gameObject)
        {
            ball.Remove(gameObject);
            BallDeleteEvent?.Invoke(ball.Count);
        }
    }
}
