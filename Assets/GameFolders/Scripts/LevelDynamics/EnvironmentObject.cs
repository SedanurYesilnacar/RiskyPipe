
using RiskyPipe3D.Enums;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
    public class EnvironmentObject : MonoBehaviour
    {
        [SerializeField] private EnvironmentType _environmentType= EnvironmentType.Energy;

        public EnvironmentType EnvironmentType { get => _environmentType; }
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
            gameObject.SetActive(true);
        }

        


        public void SetRotation(PipeType pipeType)
        {
            if (pipeType.Equals(PipeType.Vertical))
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
            }
            else if(pipeType.Equals(PipeType.LeftHorizontal))
            {
                transform.rotation = Quaternion.Euler(-90 * Vector3.up);
            }
            else if(pipeType.Equals(PipeType.RightHorizontal))
            {
                transform.rotation = Quaternion.Euler(90 * Vector3.up);
            }
        }

        public void Deactive()
        {
            gameObject.SetActive(false);
        }
    }
}
