using UnityEngine;

namespace Assets.LoopGame.Scripts.Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BaseBall : MonoBehaviour, IBallAction
    {
        private Rigidbody2D _rb;
        private bool _isActive = false;
        private GameProperty _gameProperty;
        
        private void Start()
        {
            if(_gameProperty == null) Destroy(gameObject);
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Construct(GameProperty gameProperty)
        {
            _gameProperty = gameProperty;
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
            _rb.AddForce(direction.normalized * _gameProperty.speedBall, ForceMode2D.Impulse);
        }
        private void FixedUpdate()
        {
            FixMoveAngle();
        }
        public void ChangeParent(Transform parent)
        {
            transform.SetParent(parent);
            _rb.velocity = Vector2.zero;
            _isActive = !_isActive;
            _rb.bodyType = RigidbodyType2D.Dynamic;
        }

        private void FixMoveAngle()
        {
            float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
            if (angle < 0)
            {
                angle += 360f;
            }
            if (angle > 160 && angle < 200 || angle < 30 && angle > 330)
            {
                Push(new Vector2(_rb.velocity.x * 0.83f, _rb.velocity.y));
            }
        }
    }
}
