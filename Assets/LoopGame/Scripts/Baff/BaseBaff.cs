using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Baff
{
    [RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
    public class BaseBaff: MonoBehaviour
    {
        protected GameProperty _gameProperty;
        public void Construct(GameProperty gamePropert)
        {
            _gameProperty = gamePropert;
        }
        protected virtual void AddBuff()
        {

        }
    }
}
