using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.LoopGame.Scripts.Cube
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BaseCube: MonoBehaviour, IHealth
    {
        private int _health = 1;

        public void AddHealth(int value)
        {
            if(value > 0)
            {
                _health += value;
            }
        }

        public void SubHealth(int value) 
        { 
            if(value < 0)
            {
                _health -= value;
                if (value < 0)
                {
                    DestroyCube();
                }
            }

        }

        private void DestroyCube()
        {
            Destroy(gameObject);
        }

    }
}
