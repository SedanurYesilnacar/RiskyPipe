using UnityEngine;

namespace RiskyPipe3D.GameDynamics
{
    public class ScaleIt : IScale
    {
        private Vector3 _maxScale;
        private Vector3 _minScale;
        private float _scaleSpeed;
        public ScaleIt(float minScale, float maxScale, float scaleSpeed)
        {
            _maxScale = Vector3.one * maxScale;
            _minScale = Vector3.one * minScale;
            _scaleSpeed = scaleSpeed;
        }
        public void Execute(Transform transform, float vertical)
        {
            transform.localScale += Vector3.one * vertical * _scaleSpeed * Time.fixedDeltaTime;
            if (transform.localScale.x > _maxScale.x)
                transform.localScale = _maxScale;
            if (transform.localScale.x < _minScale.x)
                transform.localScale = _minScale;
        }
    }
}
