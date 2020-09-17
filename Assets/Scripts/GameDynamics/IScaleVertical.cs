namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public interface IScaleVertical
    {
        Transform GetTransform();
        float GetVertical();
        Vector3 GetMaxScale();
        Vector3 GetMinScale();
        float GetScaleSpeed();
    }
}
