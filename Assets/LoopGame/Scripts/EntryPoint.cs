using Assets.LoopGame.Scripts.Ball;
using Assets.LoopGame.Scripts.Factory;
using Assets.LoopGame.Scripts.Inputs;
using Assets.LoopGame.Scripts.Level;
using Assets.LoopGame.Scripts.Player;
using TMPro;
using UnityEngine;

namespace Assets.LoopGame.Scripts
{
    public class EntryPoint:MonoBehaviour
    {
        #region UI
        public TextMeshProUGUI scoreView;
        public TextMeshProUGUI healthView;
        #endregion

        private IMoveble moveble = new PCInput();

        private GameProperty _gameProperty = new GameProperty();


        #region Prefabs
        public GameObject playerPref;
        public GameObject ballPref;
        public СarriageMoveble carriage;
        #endregion

        #region MapGenerate
        public Transform startPointCube;
        public Transform startPointPlayer;
        public Transform startPointBall;
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
            UpdateHealthView();
            CreateBall();
        }

        private void Subs()
        {
            _gameProperty.ScoreEvent += _ => UpdateScoreView();
            _gameProperty.BallDeleteEvent +=  StateBallHealth;
        }

        private void CreateBall()
        {
            var ball = GameObject.Instantiate(ballPref,playerPref.transform);
            var ballMonobeh = ball.GetComponent<BaseBall>();
            ballMonobeh.Construct(_gameProperty);
            _gameProperty.AddBall(ball);

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
        private void UpdateHealthView()
        {
            if (healthView != null)
            {
                healthView.text = _gameProperty.Health.ToString();
            }
        }

        private void StateBallHealth(int count)
        {
            if (count == 0)
            {
                _gameProperty.Health -= 1;
                UpdateHealthView();
            }
            if (_gameProperty.Health == 0)
            {
                Debug.Log("END");
            }
            else if (count == 0)
            {
                {
                    CreateBall();
                }
            }
        }
    }
}
