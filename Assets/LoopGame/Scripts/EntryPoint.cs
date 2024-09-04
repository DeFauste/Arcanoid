using Assets.LoopGame.Scripts.Inputs;
using Assets.LoopGame.Scripts.Player;
using UnityEngine;

namespace Assets.LoopGame.Scripts
{
    public class EntryPoint:MonoBehaviour
    {
        public GameObject playerPref;
        private IMoveble moveble = new PCInput();
        public СarriageMoveble  carriage;

        private void Start()
        {
            carriage.Construct(playerPref, moveble);
        }

    }
}
