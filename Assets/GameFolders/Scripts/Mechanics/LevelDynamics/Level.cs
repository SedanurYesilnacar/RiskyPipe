namespace RiskyPipe3D.LevelDynamics
{
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    using RiskyPipe3D.Enums;

    public class Level
    {
        private List<BasePipe> _pipes;

        private List<BasePipe> _pointPipes;

        private List<Trap> _traps;

        private int _lenght;

        Direction direction = Direction.Forward;

        private int randomMinLenght = 4;
        private int randomMaxLength = 8;

        public Level(int length)
        {
            _lenght = length;
            _pipes = new List<BasePipe>();
            _pointPipes = new List<BasePipe>();
            _traps = new List<Trap>();
        }

        public void Initialize()
        {
            Pipe currentPipe = PipeFactory.Instance.GetPipe(PipeType.Vertical) as Pipe;
            while(_lenght-- > 0)
            {
                currentPipe = PipeFactory.Instance.GetPipe(currentPipe.AfterPipeType) as Pipe;
                int rand = Random.Range(randomMinLenght, randomMaxLength);
                for(int i = 0; i < rand; i++)
                {
                    BasePipe pipe = MonoBehaviour.Instantiate(currentPipe).GetComponent<Pipe>();
                    _pipes.Add(pipe);
                    _lenght--;
                }
                currentPipe = PipeFactory.Instance.GetDirectionPipe(currentPipe.PipeType) as Pipe;
                _pipes.Add(MonoBehaviour.Instantiate(currentPipe).GetComponent<BasePipe>());
            }
            // TODO : Add finish stage
        }

        public void LoadLevel()
        {
            if (_pipes.Count == 0)
                return;
            for(int i = 1; i < _pipes.Count; i++)
            {
                ((Pipe)_pipes[i]).SetObject((Pipe)_pipes[i - 1]);
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
