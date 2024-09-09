using UnityEngine;

namespace Assets.LoopGame.Scripts.Cube
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class TouchDestroy:MonoBehaviour
    {
        public EntryPoint EntryPoint;
        private void OnTriggerEnter2D(Collider2D collision)
        {
           if(EntryPoint != null) 
            {
                EntryPoint._gameProperty.RemoveBall(collision.gameObject);
            }
        }
    }
}
