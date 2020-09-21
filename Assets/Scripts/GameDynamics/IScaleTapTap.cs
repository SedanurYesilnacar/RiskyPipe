namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public interface IScaleTapTap
    {
        Transform GetTransform();
        float GetScaleSpeed();
        Vector3 GetMaxScale();
        Vector3 GetMinScale();

        bool GetTapTapStatue();

    }
}
