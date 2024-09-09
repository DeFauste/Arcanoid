using Assets.LoopGame.Scripts.Ball;
using Assets.LoopGame.Scripts.Factory;
using Assets.LoopGame.Scripts.Inputs;
using Assets.LoopGame.Scripts.Level;
using Assets.LoopGame.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.LoopGame.Scripts
{
    public class EntryPoint:MonoBehaviour
    {
        #region UI
        public TextMeshProUGUI scoreView;
        public TextMeshProUGUI healthView;
        public TextMeshProUGUI lvlView;
        public GameObject gameOverView;
        public GameObject gameWinView;
        public GameObject menuView;
        #endregion

        private IMoveble moveble = new PCInput();

        public GameProperty _gameProperty = new GameProperty();
        private int _health = 0;

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
            Subs();
            _health = _gameProperty.Health;
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
            lvlView.text = _gameProperty.currentLvl.ToString();
            _gameProperty.cubs = _printMap.CreateNextLevel(startPointCube, _gameProperty.currentLvl);
            _gameProperty.currentLvl++;
            _gameProperty.speedBall += 0.8f;
            CreateBall();
        }

        private void UpdateScoreView()
        {
            if (scoreView != null)
            {
                scoreView.text = _gameProperty.Score.ToString();
            }
            if(_gameProperty.cubs != null && _gameProperty.cubs.Count < 1)
            {
                GameWin();
            }
        }
        private void UpdateHealthView()
        {
            if (healthView != null)
            {
                healthView.text = _gameProperty.Health.ToString();
            }
        }

        public void StartGame()
        {
            carriage.OnOfMove = true;
            NextLvl();
            UpdateHealthView();
            UpdateScoreView();
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
                GameOver();
            }
            else if (count == 0)
            {
                {
                    CreateBall();
                }
            }
        }
        private void GameOver()
        {
           if(menuView != null) menuView.SetActive(false);
            if (gameOverView != null)
            {
                gameOverView.SetActive(true);
                var txt = GameObject.Find("ScoreOverTXT").GetComponent<TextMeshProUGUI>();
                if(txt != null) txt.text = _gameProperty.Score.ToString();
            }
            if (carriage != null)
            {
                carriage.OnOfMove = false;
            }

        }
        public void RestartGame()
        {
            _gameProperty.currentLvl = 1;
            _gameProperty.Score = 0;
            _gameProperty.Health = _health;
            StartGame();
        }

        private void GameWin()
        {
            if (menuView != null) menuView.SetActive(false);
            if (gameWinView != null)
            {
                gameWinView.SetActive(true);
                var txt = GameObject.Find("ScoreWinTXT").GetComponent<TextMeshProUGUI>();
                if (txt != null) txt.text = _gameProperty.Score.ToString();
                _gameProperty.DeleteAllBall();
            }
        }
    }
}
