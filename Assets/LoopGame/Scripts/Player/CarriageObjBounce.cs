using Assets.LoopGame.Scripts.Ball;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CarriageObjBounce : MonoBehaviour
    {
        private BoxCollider2D _collider;
        private void Start()
        {
            _collider = GetComponent<BoxCollider2D>();
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            NewAngluar(collision);
        }

        void NewAngluar(Collision2D collision)
        {
            IBallAction pushI = collision.gameObject.GetComponent<IBallAction>();
            if (pushI != null)
            {

                float bit = 1 / (_collider.bounds.size.x*1.2f / 2);
                float pointX = collision.gameObject.transform.position.x - gameObject.transform.position.x;
                float pointY = Mathf.Sin(Mathf.PI/(pointX*bit));
                Vector2 direction = new Vector2(pointX, Mathf.Abs(pointY));
                pushI.Push(direction);
            }
        }
    }


}
