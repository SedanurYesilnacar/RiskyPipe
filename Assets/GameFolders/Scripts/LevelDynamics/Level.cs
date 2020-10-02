namespace RiskyPipe3D.LevelDynamics
{
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;

    public class Level : ILevel
    {
        private List<BasePipe> _pipes;

        private List<BasePipe> _pointPipes;

        private List<Trap> _traps;



        private int _lenght;
        private int _level;
        private int _score;

        Direction direction = Direction.Forward;

        private int randomMinLenght = 4;
        private int randomMaxLength = 15;

        public Level(int level)
        {
            _level = level;
            _lenght = CalculateLenght();
            _pipes = new List<BasePipe>();
            _pointPipes = new List<BasePipe>();
            _traps = new List<Trap>();
            EventManager.Instance.ScoreIncreased += OnScoreIncreased;
            EventManager.Instance.ScoreResettt += ResetScore;

        }

        private void OnScoreIncreased()
        {
            _score += 1;
            if (_score > Game.Instance.GetPlayer().HighScore)
                Game.Instance.GetPlayer().HighScore = _score;
            EventManager.Instance.ScoreChange(_score);
        }
        private void ResetScore()
        {
            _score = 0;
        }


        private int CalculateLenght()
        {
            return 50;
        }

        public void Initialize()
        {
            Pipe currentPipe = PipeFactory.Instance.GetPipe(PipeType.Vertical) as Pipe;
            _pipes.Add(currentPipe);
            _lenght--;
            while(_lenght-- > 0)
            {
                int rand = Random.Range(randomMinLenght, randomMaxLength);
                for(int i = 0; i < rand; i++)
                {
                    currentPipe = PipeFactory.Instance.GetPipe(currentPipe.AfterPipeType) as Pipe;
                    _pipes.Add(currentPipe);
                    _lenght--;
                }
                currentPipe = PipeFactory.Instance.GetDirectionPipe(currentPipe.PipeType) as Pipe;
                _pipes.Add(currentPipe);
            }
            // TODO : Add finish stage
            BasePipe finishPipe = PipeFactory.Instance.GetFinishPipe(currentPipe.PipeType);
            _pipes.Add(finishPipe);
        }
        public void LoadLevel()
        {
            if (_pipes.Count == 0)
                return;
            for(int i = 1; i < _pipes.Count; i++)
            {
                _pipes[i].SetObject(_pipes[i - 1]);
            }
            LoadTraps();
        }

        public void RestartLevel()
        {
            EndLevel();
        }

        public void EndLevel()
        {
            EventManager.Instance.ScoreIncreased -= OnScoreIncreased;
            foreach(BasePipe pipe in _pipes)
            {
                pipe.DeActive();
                EventManager.Instance.PipeDeActivate(pipe);
            }
        }


        public void LoadTraps()
        { 

        Debug.Log(_pipes.Count);
            for(int i = 3; i< _pipes.Count; i+=2)
            {
                Debug.Log("a");
                BasePipe currentPipe = _pipes[i];


                if (!(_pipes[i-1] as MidPipe || _pipes[i + 1] as MidPipe))
                {
                    if (currentPipe.PipeType == PipeType.LeftHorizontal || currentPipe.PipeType == PipeType.RightHorizontal || currentPipe.PipeType == PipeType.Vertical)
                    {
                        Debug.Log("a2");
                        Trap trap = MonoBehaviour.Instantiate(TrapFactory.Instance.GetTrap()).GetComponent<Trap>();
                        _traps.Add(trap);
                        trap.SetPosition(currentPipe.transform.position);
                        trap.SetRotation(currentPipe.PipeType);
                        if (!trap.CompareTag("EnergyTrap"))
                        {
                            trap.SetScale(Random.Range(2, 5));
                        }
                    }
                }

                
                
            }
        }

    }
}
