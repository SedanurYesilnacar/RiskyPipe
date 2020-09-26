using UnityEngine;

namespace RiskyPipe3D.GameDynamics
{
    public class Rotate : ICommand
    {
        private IRotate _rotate;
        public Rotate(IRotate rotate)
        {
            _rotate = rotate;
        }

        public void Execute()
        {
            if (_rotate.GetCenterObject() == null)
            {
                _rotate.SpeedUp();
                return;
            }
            _rotate.SpeedDown();
            Vector3 _toRotation = _rotate.GetLastRotation() + Vector3.up * (_rotate.GetDirection() == Enums.Direction.Right ? 90f : -90f);
            if(_rotate.GetTransform().rotation.eulerAngles.y > _toRotation.y)
            {
                _rotate.GetTransform().rotation = Quaternion.Euler(_toRotation);
                _rotate.SpeedUp();
                return;
            }
            _rotate.GetTransform().RotateAround(_rotate.GetCenterObject(), Vector3.up * (_rotate.GetDirection() == Enums.Direction.Right ? 1 : -1), _rotate.GetTurnSpeed());
        }
    }
}
