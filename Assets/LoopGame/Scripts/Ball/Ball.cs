using UnityEngine;

namespace Assets.LoopGame.Scripts.Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball: MonoBehaviour
    {
        public float speed = 2f;
        private Rigidbody2D _rb;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            Push();
        }

        private void Push()
        {
            _rb.velocity = new Vector2(0,speed);
        }
    }
}
