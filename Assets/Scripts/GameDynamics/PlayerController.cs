namespace RiskyPipe3D.GameDynamics
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _defaultSpeed = .5f;
        [SerializeField] private float _turnSpeed = 10f;
        [SerializeField] private float _scaleSpeed = .1f;
        [SerializeField] private float _maxScale = 2f;
        [SerializeField] private float _minScale = 1f;

        private IMove _moveForward;
        private IScale _scaleIt;

        private Dictionary<Direction, IRotate> _rotations;

        private Joystick _joystick;

        private float _speed;

        private void Awake()
        {
            _speed = _defaultSpeed;
            _joystick = FindObjectOfType<Joystick>();
            _rotations = new Dictionary<Direction, IRotate>();
            _moveForward = new MoveForward();
            _scaleIt = new ScaleIt(_minScale, _maxScale, _scaleSpeed);
            _rotations.Add(Direction.Left, new RotateLeft());
            _rotations.Add(Direction.Right, new RotateRight());
        }

        private void FixedUpdate()
        {
            _moveForward.Execute(transform, _speed);
            _scaleIt.Execute(transform, _joystick.Vertical);
        }

        private IEnumerator Rotate(Direction direction)
        {
            var wait = new WaitForSeconds(.1f);
            int count = 0;
            _rotations[direction].SetToRotation(transform.rotation.eulerAngles);
            while(!_rotations[direction].Execute(transform, _turnSpeed) && count++ < (90/_turnSpeed))
            {
                yield return wait;
            }
        }

        public void Rotation(Direction direction)
        {
            StartCoroutine(Rotate(direction));
        }

        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        public void SpeedDown()
        {
            _speed = .5f;
        }

        public void SpeedUp()
        {
            _speed = _defaultSpeed;
        }

    }
}
