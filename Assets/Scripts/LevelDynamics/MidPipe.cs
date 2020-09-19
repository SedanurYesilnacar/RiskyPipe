namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using UnityEngine;

    public class MidPipe : BasePipe
    {
        [SerializeField] private PipeType _startPipeType;
        [SerializeField] private PipeType _endPipeType;
        public PipeType StartPipeType { get => _startPipeType; }
        public PipeType EndPipeType { get => _endPipeType; }
    }
}
