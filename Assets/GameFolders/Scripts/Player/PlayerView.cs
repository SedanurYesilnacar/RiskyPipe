namespace RiskyPipe3D
{
    using RiskyPipe3D.Scripts.Managers;
    public class PlayerView
    {
        private int _highScore;
        public int HighScore {
            get => _highScore;
            set
            {
                if(value != _highScore)
                {
                    _highScore = value;
                    HighScoreChanged?.Invoke(value);
                    ValueChanged?.Invoke(this);
                }
            }
        }
        private int _level;
        public int Level { 
            get => _level;
            set
            {
                if(value != _level)
                {
                    _level = value;
                    LevelChanged?.Invoke(value);
                    ValueChanged?.Invoke(this);
                }
            }
        }
        private int _totalCoin;
        public int TotalCoin { 
            get => _totalCoin;
            set
            {
                if(_totalCoin != value)
                {
                    _totalCoin = value;
                    TotalCoinChanged?.Invoke(value);
                    ValueChanged?.Invoke(this);
                }
            }
        }

        private float _defaultSpeed;
        public float DefaultSpeed
        {
            get => _defaultSpeed;
            set
            {
                if(_defaultSpeed != value)
                {
                    _defaultSpeed = value;
                    ValueChanged?.Invoke(this);
                    SpeedChanged?.Invoke(value);
                }
            }
        }

        public delegate void HighScoreChange(int highScore);
        public event HighScoreChange HighScoreChanged;
        public delegate void LevelChange(int level);
        public event LevelChange LevelChanged;
        public delegate void TotalCoinChange(int totalCoin);
        public event TotalCoinChange TotalCoinChanged;
        public delegate void ValueChange(PlayerView p);
        public event ValueChange ValueChanged;
        public delegate void SpeedChange(float defaultSpeed);
        public event SpeedChange SpeedChanged;

        public PlayerView(PlayerData player)
        {
            _totalCoin = player.totalCoin;
            _level = player.level;
            _highScore = player.highScore;
            _defaultSpeed = player.defaultSpeed;
        }

    }
}
