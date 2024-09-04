using UnityEngine;

namespace Assets.LoopGame.Scripts.Ball
{
    public interface IBallAction
    {
        void Push(Vector2 direction);
        void ChangeParent(Transform  parent);
    }
}