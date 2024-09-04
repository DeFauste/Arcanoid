using UnityEngine;

namespace Assets.LoopGame.Scripts.Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour, IBallAction
    {
        public float _speed = 5f;
        private Rigidbody2D _rb;
        private bool _isActive = false;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(!_isActive && Input.GetKeyDown(KeyCode.Space))
            {
                float xDirection = Random.Range(-0.3f, 0.3f);
                ChangeParent(null);
                Push(new Vector2(xDirection, 1));
            }
        }
        public void Push(Vector2 direction)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(direction.normalized * _speed,ForceMode2D.Impulse);
        }

        public void ChangeParent(Transform parent)
        {
            transform.SetParent(parent);
            _rb.velocity = Vector2.zero;
            _isActive = !_isActive;
            _rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
