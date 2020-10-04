namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections.Generic;
    using UnityEngine;
    public class Pipe : BasePipe
    {
        [SerializeField] private Direction _direction=Direction.Forward;
        public Direction Direction { get => _direction; }
        [SerializeField] private PipeType _beforePipeType=PipeType.PointPipe;
        public PipeType BeforePipeType { get => _beforePipeType; }
        [SerializeField] private PipeType _afterPipeType= PipeType.PointPipe;
        public PipeType AfterPipeType { get => _afterPipeType; }
        
      
    }
}
