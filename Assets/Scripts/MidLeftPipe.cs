
namespace RiskyPipe3D
{
    using RiskyPipe3D.GameDynamics;
    public class MidLeftPipe : BasePipe
    {
        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController pController = other.GetComponent<PlayerController>();
                pController.Rotation(Direction.Left);
                pController.SpeedDown();
            }
        }

    }
}
