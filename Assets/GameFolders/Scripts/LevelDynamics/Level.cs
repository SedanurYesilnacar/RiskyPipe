namespace RiskyPipe3D.LevelDynamics
{
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using RiskyPipe3D.Extensions;

    public class Level : ILevel
    {
        private List<BasePipe> _pipes;

        private List<BasePipe> _pointPipes;

        private List<EnvironmentObject> _environments;

        private int _lenght;
        private int _level;
        private int _score;

        private int randomMinLenght = 4;
        private int randomMaxLength = 15;

        public Level(int level)
        {
            _level = level;
            _lenght = CalculateLenght(level);
            _pipes = new List<BasePipe>();
            _pointPipes = new List<BasePipe>();
            _environments = new List<EnvironmentObject>();
            EventManager.Instance.ScoreIncreased += OnScoreIncreased;
            EventManager.Instance.ScoreResettt += ResetScore;
            EventManager.Instance.MultipierSetted += OnMultipierSetted;

        }

        private void OnMultipierSetted(int multipier)
        {
            _score *= multipier;
            if (_score > Game.Instance.GetPlayer().HighScore)
                Game.Instance.GetPlayer().HighScore = _score;
            EventManager.Instance.ScoreChange(_score);
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


        private int CalculateLenght(int playerLevel)
        {
            int size = 30;
            if (playerLevel < 10)
            {
                size = Random.Range(20, 30);
            }
            else if (playerLevel < 20)
            {
                size = Random.Range(30, 40);
            }
            else if (playerLevel < 30)
            {
                size = Random.Range(40, 50);
            }
            else if (playerLevel < 50)
            {
                size = Random.Range(50, 60);
            }
            else
            {
                size = Random.Range(60, 100);
            }
            return size;
        }

        public void Initialize()
        {
            Pipe currentPipe = PipeFactory.Instance.GetPipe(PipeType.Vertical) as Pipe;
            _pipes.Add(currentPipe);
            _lenght--;
            while (_lenght-- > 0)
            {
                int rand = Random.Range(randomMinLenght, randomMaxLength);
                for (int i = 0; i < rand; i++)
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
            for (int i = 1; i < _pipes.Count; i++)
            {
                _pipes[i].SetObject(_pipes[i - 1]);
            }
            LoadTraps();
        }

        public void RestartLevel()
        {

        }

        public void EndLevel()
        {
            EventManager.Instance.ScoreIncreased -= OnScoreIncreased;
            foreach (BasePipe pipe in _pipes)
            {
                pipe.DeActive();
                EventManager.Instance.PipeDeActivate(pipe);
            }
            foreach (EnvironmentObject environmentObject in _environments)
            {
                environmentObject.Deactive();
                EventManager.Instance.EnvironmentObjectDeactivate(environmentObject);
            }
            EventManager.Instance.ScoreIncreased -= OnScoreIncreased;
            EventManager.Instance.ScoreResettt -= ResetScore;
            EventManager.Instance.MultipierSetted -= OnMultipierSetted;
        }


        public void LoadTraps()
        {
            int currentIndex = 3;
            while (currentIndex < _pipes.Count - 1)
            {
                int lastIndex = _pipes.GetMidPipeIndex(currentIndex);
                if (lastIndex < 0)
                {
                    break;
                }
                bool isEnergyPlaced = false;
                bool isOnTrap = false;
                for (int i = currentIndex; i < lastIndex - 1; i++)
                {
                    if (isOnTrap)
                    {
                        isOnTrap = false;
                        continue;
                    }
                    if (Random.Range(0, 2) == 0 && !isOnTrap)
                    {
                        Trap trap;
                        trap = (Trap)EnvironmentFactory.Instance.GetEnvironmentObject(Random.Range(0, 3) == 0 ? EnvironmentType.RingTrap : EnvironmentType.Trap);
                        trap.SetPosition(_pipes[i].EndPoint.position);
                        trap.SetRotation(_pipes[i].PipeType);
                        trap.SetScale();
                        _environments.Add(trap);
                        isOnTrap = true;
                    }

                    if (!isEnergyPlaced)
                    {
                        Energy energy;
                        energy = (Energy)EnvironmentFactory.Instance.GetEnvironmentObject(EnvironmentType.Energy);
                        energy.SetPosition(_pipes[i].EndPoint.position);
                        energy.SetRotation(_pipes[i].PipeType);
                        energy.SetScale(lastIndex - i - 1);
                        _environments.Add(energy);
                        isEnergyPlaced = true;
                    }

                }
                currentIndex = lastIndex + 1;
            }
        }


    }
}
