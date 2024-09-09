using Assets.LoopGame.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Baff
{
    public class HealthBaff : BaseBaff
    {
        [SerializeField] private int Health = 1;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                AddBuff();
            } else if(collision.CompareTag("Destroyer"))
            {
                Destroy(gameObject);
            }
        }
        protected override void AddBuff() 
        {
           if(_gameProperty != null) _gameProperty.Health += Health;
            Destroy(gameObject);
        }
    }
}
