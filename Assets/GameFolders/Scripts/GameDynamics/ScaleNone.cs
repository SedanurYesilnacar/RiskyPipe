namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public class ScaleNone : ICommand
    {
        private IScaleNone _scaleNone;
        private float _scaleDownValue = .1f;
        public ScaleNone(IScaleNone scaleNone)
        {
            _scaleNone = scaleNone;
        }

        public void Execute()
        {
            _scaleNone.GetTransform().localScale -= Vector3.one * _scaleDownValue * Time.deltaTime;
            if (_scaleNone.GetTransform().localScale.x < _scaleNone.GetMinScale().x)
                _scaleNone.GetTransform().localScale = _scaleNone.GetMinScale();
        }
    }
}
