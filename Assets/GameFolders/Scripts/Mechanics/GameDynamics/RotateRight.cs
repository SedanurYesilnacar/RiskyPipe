namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public class RotateRight : ICommand
    {
        private IRotate _rotate;
        public RotateRight(IRotate rotate)
        {
            _rotate = rotate;
        }

        public void Execute()
        {
            Vector3 _toRotation = _rotate.GetLastRotation() + (Vector3.up * 90);
            _rotate.GetTransform().rotation = Quaternion.RotateTowards(_rotate.GetTransform().rotation, Quaternion.Euler(_toRotation), _rotate.GetTurnSpeed());
        }
    }
}
