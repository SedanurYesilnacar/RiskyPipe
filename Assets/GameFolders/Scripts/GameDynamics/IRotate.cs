namespace RiskyPipe3D.GameDynamics
{
    using RiskyPipe3D.Enums;
    using UnityEngine;
    public interface IRotate
    {
        Transform GetTransform();
        float GetTurnSpeed();
        Direction GetDirection();
        Vector3 GetLastRotation();
        Vector3 GetCenterObject();
        void SpeedUp();
        void SpeedDown();
    }
}
