using RiskyPipe3D.GameDynamics;

namespace RiskyPipe3D
{
    public interface ICollisionStayResponse
    {
        void OnCollisionStayResponse(PlayerController player);
    }
}