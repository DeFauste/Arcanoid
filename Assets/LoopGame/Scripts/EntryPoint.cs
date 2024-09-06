using Assets.LoopGame.Scripts.Factory;
using Assets.LoopGame.Scripts.Inputs;
using Assets.LoopGame.Scripts.Level;
using Assets.LoopGame.Scripts.Player;
using UnityEngine;

namespace Assets.LoopGame.Scripts
{
    public class EntryPoint:MonoBehaviour
    {
        int currentLvl = 4;
        public Transform startPointCube;
        public GameObject playerPref;
        private IMoveble moveble = new PCInput();
        public СarriageMoveble  carriage;
        private GameProperty _gameProperty = new GameProperty();
        private FactoryCube _factoryBall;
        private PrintMap _printMap;
        private void Start()
        {
            _factoryBall = new FactoryCube(_gameProperty);
            _factoryBall.LoadPref();
            _printMap = new PrintMap(_factoryBall);
            carriage.Construct(playerPref, moveble);
            NextLvl();
            _gameProperty.ScoreEvent += LogScore;
        }

        public void NextLvl()
        {
            _printMap.PrintNextLevel(startPointCube, currentLvl);
        }

        private void LogScore(int i)
        {
            Debug.Log(_gameProperty.Score);
        }

    }
}
