namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.GameDynamics;
    using UnityEngine;

    public class MidPipe :Pipe
    {
        [SerializeField] private Transform centerObj;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController playerController = other.GetComponent<PlayerController>();
                
                playerController.SetCenterObject(centerObj);
                playerController.SetRotation(Direction);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController playerController = other.GetComponent<PlayerController>();

                GetComponent<BoxCollider>().enabled = false;
                playerController.SetCenterObject(null);
                playerController.SetPosition(EndPoint.position);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController playerController = other.GetComponent<PlayerController>();
                playerController.Rotate();
            }
        }

    }

}
