namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using UnityEngine;
    public class BasePipe : MonoBehaviour
    {

        [SerializeField] private PipeType _pipeType;
        public PipeType PipeType { get => _pipeType; }

        [SerializeField] private Transform _endPoint;
        public Transform EndPoint { get => _endPoint; }
    }
}
