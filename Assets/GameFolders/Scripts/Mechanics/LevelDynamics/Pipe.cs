namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections.Generic;
    using UnityEngine;
    public class Pipe : BasePipe
    {
        [SerializeField] private Direction _direction;
        public Direction Direction { get => _direction; }
        [SerializeField] private PipeType _beforePipeType;
        public PipeType BeforePipeType { get => _beforePipeType; }
        [SerializeField] private PipeType _afterPipeType;
        public PipeType AfterPipeType { get => _afterPipeType; }
        [SerializeField] private PipeType _pipeType;
        public PipeType PipeType { get => _pipeType; }
        [SerializeField] private Transform _endPoint;
        public Transform EndPoint { get => _endPoint; }
        public void SetObject(Pipe before = null)
        {
            if(before == null)
            {
                transform.position = Vector3.zero;
            }
            else
            {
                transform.position = before.EndPoint.position;
            }

        }
    }
}
