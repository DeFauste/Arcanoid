using Assets.LoopGame.Scripts.Cube;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Ball
{
    public class BallDamage: MonoBehaviour
    {
        public int forceAttack = 1;
        void OnCollisionEnter2D(Collision2D collision)
        {
            Attack(collision);
        }
        private void Attack(Collision2D collision)
        {
            IHealth health = collision.gameObject.GetComponent<IHealth>();
            if (health != null)
            {
                health.SubHealth(forceAttack);
            }
        }
    }
}
