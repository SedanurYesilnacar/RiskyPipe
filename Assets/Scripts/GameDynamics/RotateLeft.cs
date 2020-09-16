using UnityEngine;

namespace RiskyPipe3D.GameDynamics
{
    public class RotateLeft : IRotate
    {
        public override bool Execute(Transform transform, float turnSpeed)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_toRotation), turnSpeed);
            Debug.Log(transform.rotation.eulerAngles.y.Equals(_toRotation.y + (_toRotation.y < 0f ? 360f : 0f)));
            return transform.rotation.eulerAngles.y.Equals(_toRotation.y + (_toRotation.y < 0f ? 360f : 0f));
        }

        public override void SetToRotation(Vector3 lastRotation)
        {
            _toRotation = new Vector3(lastRotation.x, lastRotation.y - 90, lastRotation.z);
            Debug.LogError(_toRotation);
        }
    }
}
