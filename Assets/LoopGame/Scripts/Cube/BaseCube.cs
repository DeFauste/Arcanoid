using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.LoopGame.Scripts.Cube
{
    [RequireComponent(typeof(BoxCollider2D),typeof(Rigidbody2D))]
    public class BaseCube : MonoBehaviour, IHealth
    {
        private int _health = 1;

        public void AddHealth(int value)
        {
            _health += Mathf.Abs(value);
        }

        public int GetHealth() => _health;

        public void SubHealth(int value) 
        { 

            _health -= Mathf.Abs(value);
            if (_health <= 0)
            {
                DestroyCube();
            }
        }

        private void DestroyCube()
        {
            Destroy(gameObject);
        }

    }
}
