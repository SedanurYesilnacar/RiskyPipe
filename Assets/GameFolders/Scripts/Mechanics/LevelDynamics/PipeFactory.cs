
namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections.Generic;
    using UnityEngine;
    using RiskyPipe3D.Extensions;
    public class PipeFactory
    {
        public static PipeFactory Instance { get; private set; } = new PipeFactory();
        
        private List<Pipe> _pipes;
        private GameObject[] _pipeObjs;
        private PipeFactory()
        {
            _pipes = new List<Pipe>();
            _pipeObjs = Resources.LoadAll<GameObject>("Pipes");
            foreach (GameObject obj in _pipeObjs)
                _pipes.Add(obj.GetComponent<Pipe>());
        }

        public Pipe GetPipe(PipeType pipeType)
        {    
            return _pipes.GetPipe(pipeType);
        }

        public Pipe GetDirectionPipe(PipeType pipeType)
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
    }
}
