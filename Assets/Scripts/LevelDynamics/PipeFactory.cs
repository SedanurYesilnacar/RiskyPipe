
namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    public class PipeFactory
    {
        private List<GameObject> _pipeObjs;
        private List<Pipe> _pipes;

        private Pipe[] _forwardMidPipes;
        private Pipe _leftMidPipe;
        private Pipe _rightMidPipe;
        private Pipe _horizontalPipe;
        private Pipe _verticalPipe;
        public PipeFactory()
        {
            _pipes = new List<Pipe>();
            _pipeObjs = Resources.LoadAll<GameObject>("Pipes").ToList();
            foreach (GameObject obj in _pipeObjs)
                _pipes.Add(obj.GetComponent<Pipe>());

        }

    }
}
