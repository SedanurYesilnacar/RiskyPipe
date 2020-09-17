namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections.Generic;
    using UnityEngine;
    public class Pipe : MonoBehaviour
    {
        [SerializeField] private Transform _endPoint;
        [Space(20)]
        [SerializeField] private PipeType _startPipeType;
        [SerializeField] private PipeType _endPipeType;
        public Transform EndPoint { get => _endPoint; }
        public PipeType StartPipeType { get => _startPipeType; }
        public PipeType EndPipeType { get => _endPipeType; }
        public void SetObject(Pipe before = null)
        {
            if(before == null)
            {

            }
            else
            {
                transform.position = EndPoint.position;
            }

        }
    }
}
