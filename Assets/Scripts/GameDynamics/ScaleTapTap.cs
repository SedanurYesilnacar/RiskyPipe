using UnityEngine;

namespace RiskyPipe3D.GameDynamics
{
    public class ScaleTapTap : ICommand
    {
        IScaleTapTap _scaleTapTap;
        public ScaleTapTap(IScaleTapTap scaleTapTap)
        {
            _scaleTapTap = scaleTapTap;
        }

        public void Execute()
        {
            _scaleTapTap.GetTransform().localScale += _scaleTapTap.GetTransform().localScale += Vector3.one * _scaleTapTap.GetScaleSpeed() * Time.fixedDeltaTime;
            if (_scaleTapTap.GetTransform().localScale.x > _scaleTapTap.GetMaxScale().x)
                _scaleTapTap.GetTransform().localScale = _scaleTapTap.GetMaxScale();
            if (_scaleTapTap.GetTransform().localScale.x < _scaleTapTap.GetMinScale().x)
                _scaleTapTap.GetTransform().localScale = _scaleTapTap.GetMinScale();
        }
    }
}
