using UnityEngine;

namespace Assets.LoopGame.Scripts.Inputs
{
    public class PCInput :IMoveble
    {
        Vector2 _direction = Vector2.zero;
        public Vector2 Direction()
        {
            _direction.x = Input.GetAxis("Horizontal");
            return _direction;
        }
    }
}
