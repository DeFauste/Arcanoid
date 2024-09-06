using Assets.LoopGame.Scripts.Factory;
using Assets.LoopGame.Scripts.Inputs;
using Assets.LoopGame.Scripts.Level;
using Assets.LoopGame.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.LoopGame.Scripts
{
    public class EntryPoint:MonoBehaviour
    {
        #region UI
        public TextMeshProUGUI scoreView;
        #endregion

        private IMoveble moveble = new PCInput();

        private GameProperty _gameProperty = new GameProperty();

        public GameObject playerPref;
        public СarriageMoveble carriage;

        #region MapGenerate
        public Transform startPointCube;
        private FactoryCube _factoryBall;
        private CreateMap _printMap;
        #endregion  
        private void Start()
        {
            _factoryBall = new FactoryCube(_gameProperty);
            _factoryBall.LoadPref();
            _printMap = new CreateMap(_factoryBall);
            carriage.Construct(playerPref, moveble);
            NextLvl();
            Subs();
        }

        private void Subs()
        {
            _gameProperty.ScoreEvent += _ => UpdateScoreView();
        }

        public void NextLvl()
        {
            _gameProperty.cubs = _printMap.CreateNextLevel(startPointCube, _gameProperty.currentLvl);
            _gameProperty.currentLvl++;
        }


        private void UpdateScoreView()
        {
            if (scoreView != null)
            {
                scoreView.text = _gameProperty.Score.ToString();
            }
            if(_gameProperty.cubs != null && _gameProperty.cubs.Count <= 1)
            {
                NextLvl();
            }
        }

    }
}
