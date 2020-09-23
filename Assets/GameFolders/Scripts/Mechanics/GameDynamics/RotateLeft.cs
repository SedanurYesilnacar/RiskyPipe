using UnityEngine;

namespace RiskyPipe3D.GameDynamics
{
    public class RotateLeft : ICommand
    {
        private IRotate _rotate;
        public RotateLeft(IRotate rotate)
        {
            _rotate = rotate;
        }

        public void Execute()
        {
            Vector3 _toRotation = _rotate.GetLastRotation() + (Vector3.up * -90);
            _rotate.GetTransform().rotation = Quaternion.RotateTowards(_rotate.GetTransform().rotation, Quaternion.Euler(_toRotation), _rotate.GetTurnSpeed());
        }
    }
}
