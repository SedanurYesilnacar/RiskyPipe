namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    public class BasePipe : MonoBehaviour
    {

        [SerializeField] private PipeType _pipeType;
        public PipeType PipeType { get => _pipeType; }

        [SerializeField] private Transform _endPoint;
        public Transform EndPoint { get => _endPoint; }


        public void SetObject(BasePipe before = null)
        {
            if (before == null)
            {
                transform.position = Vector3.zero;
            }
            else
            {
                transform.position = before.EndPoint.position;
                Active();
                before.Active();
            }
        }

        public void DeActive()
        {
            transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }

        public void Active()
        {
            gameObject.SetActive(true);
        }

    }
}
