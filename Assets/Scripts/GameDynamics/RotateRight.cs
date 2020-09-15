namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public class RotateRight : IRotate
    {
        public override bool Execute(Transform transform, float turnSpeed)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_toRotation), turnSpeed);
            //Debug.Log(transform.rotation.eulerAngles.y.Equals(_toRotation.y));
            return transform.rotation.eulerAngles.y.Equals(_toRotation.y);
        }

        public override void SetToRotation(Vector3 lastRotation)
        {
            _toRotation = new Vector3(lastRotation.x, lastRotation.y + 90, lastRotation.z);
            Debug.LogError(_toRotation);
        }
    }
}
