using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.LoopGame.Scripts
{
    public class GameProperty
    {
        public event Action<int> ScoreEvent;
        public event Action<int> BallDeleteEvent;
        private bool isWin = false;
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
            if(ball.Contains(gameObject))
            {
                ball.Remove(gameObject);
            }
            if (!isWin) BallDeleteEvent?.Invoke(ball.Count);
        }
        public void DeleteAllBall()
        {
            isWin = true;
            ball.ForEach(ball =>
            {
                if(!ball.IsDestroyed())GameObject.Destroy(ball);
            });
            ball.Clear();

            isWin = false;
        }
    }
}
