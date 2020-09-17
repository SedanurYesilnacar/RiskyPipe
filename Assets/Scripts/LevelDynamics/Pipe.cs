namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections.Generic;
    using UnityEngine;
    public class Pipe : MonoBehaviour
    {
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
