using UnityEngine;

namespace RiskyPipe3D.GameDynamics
{
    public class ScaleTapTap : ICommand
    {
        IScaleTapTap _scaleTapTap;

        private float _scaleValue = 0;
        private float _maxScaleValue = 1f;
        private float _minScaleValue = -1f;
        public ScaleTapTap(IScaleTapTap scaleTapTap)
        {
            _scaleTapTap = scaleTapTap;
        }

        public void Execute()
        {
            if(_scaleTapTap.GetTapTapStatue())
            {
                if(_scaleValue < 0)
                {
                    _scaleValue = 0;
                }
                _scaleValue += 5f * Time.fixedDeltaTime;
            }
            else
            {
                _scaleValue -= 0.5f * Time.fixedDeltaTime;
            }
            
            _scaleTapTap.GetTransform().localScale +=  _scaleValue * Time.fixedDeltaTime * new Vector3(1,1,1);
            if (_scaleTapTap.GetTransform().localScale.x > _scaleTapTap.GetMaxScale().x)
                _scaleTapTap.GetTransform().localScale = _scaleTapTap.GetMaxScale();
            if (_scaleTapTap.GetTransform().localScale.x < _scaleTapTap.GetMinScale().x)
                _scaleTapTap.GetTransform().localScale = _scaleTapTap.GetMinScale();
            if (_scaleValue > _maxScaleValue)
                _scaleValue = _maxScaleValue;
            else if (_scaleValue < _minScaleValue)
                _scaleValue = _minScaleValue;
        }
    }
}
