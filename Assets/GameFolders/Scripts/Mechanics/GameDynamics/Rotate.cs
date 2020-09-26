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
            _toRotation = new Vector3(_toRotation.x, _toRotation.y%360, _toRotation.z);
            _rotate.GetTransform().RotateAround(_rotate.GetCenterObject(), Vector3.up * (_rotate.GetDirection() == Enums.Direction.Right ? 1 : -1), _rotate.GetTurnSpeed());
            _rotate.GetTransform().rotation = Quaternion.RotateTowards(_rotate.GetTransform().rotation, Quaternion.Euler(_toRotation), _rotate.GetTurnSpeed());
            if (_rotate.GetTransform().eulerAngles.Equals(Quaternion.Euler(_toRotation).eulerAngles))
            {
                _rotate.SpeedUp();
                Debug.Log("1 : " + Quaternion.Euler(_toRotation).eulerAngles + " 2 : " + _rotate.GetTransform().eulerAngles);
            }
        }
    }
}
