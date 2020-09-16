namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public abstract class IRotate : ICommand
    {
        protected Vector3 _toRotation = Vector3.zero;
        public abstract bool Execute(Transform transform, float turnSpeed);
        public abstract void SetToRotation(Vector3 lastRotation);
    }
    public enum Direction
    {
        Right,
        Left
    }
}
