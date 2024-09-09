using Assets.LoopGame.Scripts.Inputs;
using System;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Player
{
    public class СarriageMoveble:MonoBehaviour
    {
        private GameObject _carriage;
        private IMoveble _moveble;
        private Rigidbody2D _rbCarriage;
        public bool OnOfMove = false;
        public void Construct(GameObject carriage, IMoveble moveble)
        {
            _carriage = carriage;
            _moveble = moveble;
            _rbCarriage = carriage.GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (_rbCarriage != null && _moveble != null && OnOfMove)
            {
                _rbCarriage.velocity = new Vector2(10 * _moveble.Direction().x, 0);
            }
        }
    }
}
