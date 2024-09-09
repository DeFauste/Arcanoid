using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Assets.LoopGame.Scripts.Cube
{
    [RequireComponent(typeof(BoxCollider2D),typeof(Rigidbody2D))]
    public class BaseCube : MonoBehaviour, IHealth
    {
        [SerializeField] private int _health = 1;
        [SerializeField] private int _cost = 1;
        private GameProperty _property;
        public void Construct(GameProperty score)
        {
            _property = score;
        }

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

        protected virtual void DestroyCube()
        {
            if (_property != null)
            {
                _property.RemoveCube(gameObject);
                _property.Score = _cost;
            }
            Destroy(gameObject);
        }

    }
}
