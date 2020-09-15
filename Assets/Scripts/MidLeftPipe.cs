
namespace RiskyPipe3D
{
    using RiskyPipe3D.GameDynamics;
    public class MidLeftPipe : BasePipe
    {
        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            if (other.CompareTag("Player"))
                other.GetComponent<PlayerController>().Rotation(Direction.Left);
        }
    }
}
