using RiskyPipe3D.GameDynamics;

namespace RiskyPipe3D
{
    public interface ICollisionExitResponse
    {
        void OnCollisionExitResponse(PlayerController player);
    }
}