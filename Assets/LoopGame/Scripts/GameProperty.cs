using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.LoopGame.Scripts
{
    public class GameProperty
    {
        public event Action<int> ScoreEvent;
        public event Action<int> HealthEvent;
        public event Action<int> BallDeleteEvent;
        public event Action<Vector2> CubePositionDelete;
        private bool isWin = false;
        public int currentLvl = 1;
        public float speedBall = 5;
        public float speedPlayer = 7;
        public int BaffScore = 200;
        private int health = 3;
        public int Health { 
            get => health;
            set
            {
                health = value;
                HealthEvent?.Invoke(health);
            }
        }

        private int score = 0;
        public int Score {
            get => score;
            set
            {
                score += value;
                ScoreEvent?.Invoke(score);
            }
        }
        public List<GameObject> cubs;
        public void RemoveCube(GameObject cube)
        {
            CubePositionDelete?.Invoke(cube.transform.position);
            cubs.Remove(cube);
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
            if (!isWin)
            {
                BallDeleteEvent?.Invoke(ball.Count);
            }
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
