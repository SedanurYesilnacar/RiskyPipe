namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public interface IRotate
    {
        Transform GetTransform();
        float GetTurnSpeed();
        Vector3 GetLastRotation();
    }
}
