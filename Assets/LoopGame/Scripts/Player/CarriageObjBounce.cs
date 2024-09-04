using UnityEngine;

namespace Assets.LoopGame.Scripts.Player
{
    public class CarriageObjBounce : MonoBehaviour
    {
        private BoxCollider2D collider;
        private void Start()
        {
            collider = GetComponent<BoxCollider2D>();
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            var rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {

                float bit = 1/(collider.bounds.size.x/2);
                float pointX = collision.gameObject.transform.position.x - gameObject.transform.position.x;
                float pointY = Mathf.Sin(pointX*bit);
                Vector2 direction = new Vector2(pointX, Mathf.Abs(pointY));
                rb.velocity = direction;
            }
        }

        Vector3 CalculateReflection(Vector3 incomingVector, Vector3 normal)
        {
            float dotProduct = Vector3.Dot(incomingVector.normalized, normal);
            float angleRad = Mathf.Acos(dotProduct);
            float reflectionAngleRad = Mathf.PI - angleRad; // Угол отражения

            Vector3 reflectionDirection = Quaternion.Euler(0, reflectionAngleRad * Mathf.Rad2Deg, 0) * incomingVector.normalized;
            return reflectionDirection * incomingVector.magnitude;
        }
    }


}
