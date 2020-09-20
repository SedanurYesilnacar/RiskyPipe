namespace RiskyPipe3D.LevelDynamics
{
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    using RiskyPipe3D.Enums;

    public class Level
    {
        private List<Pipe> _pipes;

        private int _lenght;
        
        private int randomMinLenght = 4;
        private int randomMaxLength = 8;

        public Level(int length)
        {
            _lenght = length;
            _pipes = new List<Pipe>();
        }

        public void Initialize()
        {
            Pipe currentPipe = PipeFactory.Instance.GetPipe(Enums.PipeType.Vertical);
            while(_lenght-- > 0)
            {
                int rand = Random.Range(randomMinLenght, randomMaxLength);
                for(int i = 0; i < rand && i < _lenght; i++)
                {
                    _pipes.Add(MonoBehaviour.Instantiate(currentPipe).GetComponent<Pipe>());
                    _lenght--;
                }
                if (_lenght <= 0)
                    break;
                currentPipe = PipeFactory.Instance.GetDirectionPipe(currentPipe.PipeType);
                _pipes.Add(MonoBehaviour.Instantiate(currentPipe).GetComponent<Pipe>());
                if (currentPipe.PipeType.Equals(PipeType.VerticalLeft))
                    currentPipe = PipeFactory.Instance.GetPipe(PipeType.LeftHorizontal);
                else if (currentPipe.PipeType.Equals(PipeType.VerticalRight))
                    currentPipe = PipeFactory.Instance.GetPipe(PipeType.RightHorizontal);
                else
                    currentPipe = PipeFactory.Instance.GetPipe(PipeType.Vertical);
            }
            Direction direction = Direction.Forward;
            if(currentPipe.PipeType.Equals(PipeType.LeftHorizontal))
            {
                direction = Direction.Left;
            }
            else if(currentPipe.PipeType.Equals(PipeType.RightHorizontal))
            {
                direction = Direction.Right;
            }
            currentPipe = PipeFactory.Instance.GetPipe(PipeType.FinishPipe);
            FinishPipe finishPipe = MonoBehaviour.Instantiate(currentPipe).GetComponent<FinishPipe>();
            finishPipe.SetRotation(direction);
            _pipes.Add(finishPipe);
        }

        public void LoadLevel()
        {
            if (_pipes.Count == 0)
                return;
            _pipes[0].SetObject();
            for(int i = 1; i < _pipes.Count; i++)
            {
                _pipes[i].SetObject(_pipes[i - 1]);
            }
        }

    }
}
