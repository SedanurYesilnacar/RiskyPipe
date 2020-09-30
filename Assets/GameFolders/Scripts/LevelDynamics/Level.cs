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
        private int randomMaxLength = 8;

        public Level(int level)
        {
            _level = level;
            _lenght = CalculateLenght();
            _pipes = new List<BasePipe>();
            _pointPipes = new List<BasePipe>();
            _traps = new List<Trap>();
            EventManager.Instance.ScoreIncreased += OnScoreIncreased;

        }

        private void OnScoreIncreased()
        {
            _score += 1;
            if (_score > Game.Instance.GetPlayer().HighScore)
                Game.Instance.GetPlayer().HighScore = _score;
            EventManager.Instance.ScoreChange(_score);
        }

      

        private int CalculateLenght()
        {
            return 20;
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
        }

        public void RestartLevel()
        {

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
        /*public void LoadTraps()
        {
            for(int i = 0; i<5; i++)
            {
                Trap trap = MonoBehaviour.Instantiate(TrapFactory.Instance.GetTrap()).GetComponent<Trap>();
                _traps.Add(trap);
                Pipe currentPipe = _pipes[Random.Range(0, _pipes.Count)];
                while(currentPipe as MidPipe)
                {
                    currentPipe = _pipes[Random.Range(0, _pipes.Count)];
                }
                trap.SetPosition(currentPipe.transform.position);
                trap.SetRotation(currentPipe.PipeType);
                trap.SetScale(Random.Range(2, 5));
            }
        }*/

    }
}
