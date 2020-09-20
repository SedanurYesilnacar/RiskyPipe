namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.GameDynamics;
    using UnityEngine;

    public class MidPipe :Pipe
    {
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Direction direction=Direction.Left;
                PlayerController playerController = other.GetComponent<PlayerController>();

                if (PipeType.Equals(PipeType.VerticalLeft) || PipeType.Equals(PipeType.RightVertical))
                {
                    direction = Direction.Left;
                }
                else
                {
                    direction = Direction.Right;
                }
                
                playerController.SpeedDown();
                playerController.SetRotation(direction);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController playerController = other.GetComponent<PlayerController>();

                GetComponent<BoxCollider>().enabled = false;
                playerController.SpeedUp();
                playerController.SetPosition(EndPoint.position);
            }
        }
    }

}
