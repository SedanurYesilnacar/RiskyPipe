
namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    public class PipeFactory
    {
        private List<GameObject> _pipeObjs;
        private List<BasePipe> _pipes;

        private BasePipe[] _forwardMidPipes;
        private BasePipe _leftMidPipe;
        private BasePipe _rightMidPipe;
        private BasePipe _horizontalPipe;
        private BasePipe _verticalPipe;
        public PipeFactory()
        {
            _pipes = new List<BasePipe>();
            _pipeObjs = Resources.LoadAll<GameObject>("Pipes").ToList();
            foreach (GameObject obj in _pipeObjs)
                _pipes.Add(obj.GetComponent<BasePipe>());

        }

    }
}
