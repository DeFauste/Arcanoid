using Assets.LoopGame.Scripts.Ball;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CarriageObjBall : MonoBehaviour
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

                float stepOffset = 1 / (_collider.bounds.size.x/ 2);
                float pointX = (collision.gameObject.transform.position - gameObject.transform.position).normalized.x;
                if(Mathf.Abs(pointX) > 0.8)
                {
                    pointX = pointX > 0 ? 0.8f : -0.8f;
                }
                float pointY = Mathf.Sin(Mathf.PI/(pointX* stepOffset));
                Vector2 direction = new Vector2(pointX, Mathf.Abs(pointY));
                direction = CorrectAngle(direction, stepOffset);
                pushI.Push(direction);
            }
        }
        private Vector2 CorrectAngle(Vector2 direction, float stepOffset)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle < 0)
            {
                angle += 360f;
            }
            if (angle < 30)
            {
                direction.x -= stepOffset;
            } else if(angle > 150)
            {
                direction.x += stepOffset;  
            }
            return direction;
        }
    }


}
