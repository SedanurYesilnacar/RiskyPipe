namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections.Generic;
    using UnityEngine;
    public class BasePipe : MonoBehaviour
    {
        [SerializeField] private Transform _endPoint;
        public Transform EndPoint { get => _endPoint; }
        public void SetObject(BasePipe before = null)
        {
            if(before == null)
            {
                Debug.Log("1");
            }
            else
            {
                transform.position = before.EndPoint.position;
            }

        }
    }
}
