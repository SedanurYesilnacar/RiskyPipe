namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.GameDynamics;
    using System.Collections;
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
                StartCoroutine("ColliderActivate");
                playerController.SetPosition(EndPoint.position);
                playerController.SpeedUp();
            }
        }

        private IEnumerator ColliderActivate()
        {
            GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(2f);
            GetComponent<Collider>().enabled = true;
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
