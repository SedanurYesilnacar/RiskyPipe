
namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections.Generic;
    using UnityEngine;
    using RiskyPipe3D.Extensions;
    using RiskyPipe3D.Scripts.Managers;

    public class PipeFactory
    {
        public static PipeFactory Instance { get; private set; } = new PipeFactory();

        private Dictionary<PipeType, Stack<BasePipe>> _pipesPool;

        private Dictionary<PipeType, BasePipe> _pipePrefabs;
        private GameObject[] _pipeObjs;
        private PipeFactory()
        {
            _pipesPool = new Dictionary<PipeType, Stack<BasePipe>>();
            _pipePrefabs = new Dictionary<PipeType, BasePipe>();
            _pipeObjs = Resources.LoadAll<GameObject>("Pipes");
            foreach (GameObject obj in _pipeObjs)
            {
                BasePipe pipe = obj.GetComponent<BasePipe>();
                _pipePrefabs.Add(pipe.PipeType, pipe);
            }
            EventManager.Instance.PipeDeActivated += OnPipeDeActivated;
        }

        private void OnPipeDeActivated(BasePipe pipe)
        {
            if (_pipesPool.ContainsKey(pipe.PipeType))
            {
                if(!_pipesPool[pipe.PipeType].Contains(pipe))
                    _pipesPool[pipe.PipeType].Push(pipe);
            }
            else
            {
                _pipesPool.Add(pipe.PipeType, new Stack<BasePipe>());
                _pipesPool[pipe.PipeType].Push(pipe);
            }
        }

        public BasePipe GetPipe(PipeType pipeType)
        {    
            if(_pipesPool.ContainsKey(pipeType) && _pipesPool[pipeType].Count > 0)
            {
                return _pipesPool[pipeType].Pop();
            }
            else
            {
                return GetNewPipe(pipeType);
            }
        }

        private BasePipe GetNewPipe(PipeType pipeType)
        {
            return MonoBehaviour.Instantiate(_pipePrefabs[pipeType]).GetComponent<BasePipe>();
        }

        public BasePipe GetDirectionPipe(PipeType pipeType)
        {
            PipeType pType = PipeType.VerticalLeft;
            if (pipeType == PipeType.Vertical)
            {
                pType = Random.Range(0, 2) == 0 ? PipeType.VerticalLeft : PipeType.VerticalRight;
            }
            else if (pipeType == PipeType.LeftHorizontal)
            {
                pType = PipeType.LeftVertical;
            }
            else
            {
                pType = PipeType.RightVertical;
            }
            return GetPipe(pType);
        }

        public BasePipe GetFinishPipe(PipeType pipeType)
        {
            Direction direction = Direction.Forward;
            if (pipeType.Equals(PipeType.LeftHorizontal) || pipeType.Equals(PipeType.VerticalLeft))
                direction = Direction.Left;
            else if (pipeType.Equals(PipeType.RightHorizontal) || pipeType.Equals(PipeType.VerticalRight))
                direction = Direction.Right;
            else
                direction = Direction.Forward;
            RotateablePipe finishPipe = (RotateablePipe)GetPipe(PipeType.FinishPipe);
            finishPipe.SetRotation(direction);
            return finishPipe;
        }

    }
}
