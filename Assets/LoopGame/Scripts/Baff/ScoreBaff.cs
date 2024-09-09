using Assets.LoopGame.Scripts.Cube;
using Assets.LoopGame.Scripts.Player;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Baff
{
    public class ScoreBaff: BaseBaff
    {
        [SerializeField] private int Score = 500;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                AddBuff();
            }
            else if (collision.CompareTag("Destroyer"))
            {
                Destroy(gameObject);
            }
        }
        protected override void AddBuff()
        {
            if (_gameProperty != null) _gameProperty.Score += Score;
            Destroy(gameObject);
        }
    }
}
