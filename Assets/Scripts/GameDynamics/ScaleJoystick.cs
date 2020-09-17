using UnityEngine;

namespace RiskyPipe3D.GameDynamics
{
    public class ScaleJoystick : ICommand
    {
        IScaleVertical _scaleVertical;
        public ScaleJoystick(IScaleVertical scaleVertical)
        {
            _scaleVertical = scaleVertical;
        }
        public void Execute()
        {
            _scaleVertical.GetTransform().localScale += Vector3.one * _scaleVertical.GetVertical() * _scaleVertical.GetScaleSpeed() * Time.fixedDeltaTime;
            if (_scaleVertical.GetTransform().localScale.x > _scaleVertical.GetMaxScale().x)
                _scaleVertical.GetTransform().localScale = _scaleVertical.GetMaxScale();
            if (_scaleVertical.GetTransform().localScale.x < _scaleVertical.GetMinScale().x)
                _scaleVertical.GetTransform().localScale = _scaleVertical.GetMinScale();
        }
    }
}
