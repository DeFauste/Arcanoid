using Assets.LoopGame.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Baff
{
    public class SpeedBaff:BaseBaff
    {
        [SerializeField] private float speedBust = 2f;
        [SerializeField] private float timeBustSec = 5f;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                AddBuff();
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (collision.CompareTag("Destroyer"))
            {
                Destroy(gameObject);
            }

        }
        protected override void AddBuff()
        {
            if (_gameProperty != null) StartCoroutine(TimeBaff());
        }
        IEnumerator TimeBaff()
        {
            _gameProperty.speedPlayer += speedBust;
            yield return new WaitForSeconds(timeBustSec);
          _gameProperty.speedPlayer -= speedBust;
           Destroy(gameObject);
        }
    }
}
