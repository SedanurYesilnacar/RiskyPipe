namespace RiskyPipe3D.GameDynamics
{
    using RiskyPipe3D.Enums;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class PlayerController : MonoBehaviour, IRotate, IScaleVertical, IScaleTapTap, IMove
    {
        [SerializeField] private float _defaultSpeed = .5f;
        private float _speed;
        [SerializeField] private float _turnSpeed = 10f;
        [SerializeField] private float _scaleSpeed = .1f;
        [SerializeField] private float _maxScale = 2f;
        [SerializeField] private float _minScale = 1f;

        Rigidbody _rigidbody;

        private bool _isTap;

        private ICommand _moveForward;

        private Direction _direction = Direction.Forward;
        private Dictionary<Direction, ICommand> _rotations;

        private ScaleMechanic _mechanic;

        public void ChangeMechanic(ScaleMechanic typeOfMechanic=ScaleMechanic.Joystick)
        {
            Debug.Log(typeOfMechanic.ToString());
            _mechanic = typeOfMechanic;
        }

        private Dictionary<ScaleMechanic, ICommand> _mechanics;
        private Joystick _joystick;

        // last rotation because must know before _rotation.Execute()
        private Vector3 _lastRotation = Vector3.zero;
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            ChangeMechanic();
            _rigidbody = GetComponent<Rigidbody>();
            _speed = _defaultSpeed;
            _joystick = FindObjectOfType<Joystick>();
            _rotations = new Dictionary<Direction, ICommand>();
            _mechanics = new Dictionary<ScaleMechanic, ICommand>();
            _moveForward = new MoveForward(this);
            _mechanics.Add(ScaleMechanic.Joystick, new ScaleJoystick(this));
            _mechanics.Add(ScaleMechanic.TapTap, new ScaleTapTap(this));
            _rotations.Add(Direction.Left, new RotateLeft(this));
            _rotations.Add(Direction.Right, new RotateRight(this));
            
        }

        private void FixedUpdate()
        {
            _moveForward.Execute();
            //_mechanics[_mechanic].Execute();
            if (_rotations.ContainsKey(_direction))
                _rotations[_direction].Execute();
        }

        private void Update()
        {
            if (_mechanic.Equals(ScaleMechanic.None)) return;

            _mechanics[_mechanic].Execute();
            if (_mechanic.Equals(ScaleMechanic.TapTap) && Input.GetMouseButtonDown(0))
            {
                _isTap = true;
            }
            else
            {
                _isTap = false;
            }
        }

        public void SetRotation(Direction direction)
        {
            _lastRotation = transform.rotation.eulerAngles;
            _direction = direction;
        }

        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        public void SpeedDown()
        {
            _speed = 0.5f;
        }

        public void SpeedUp()
        {
            _speed = _defaultSpeed;
        }

        #region Getters
        public Transform GetTransform()
        {
            return transform;
        }
        public float GetTurnSpeed()
        {
            return _turnSpeed;
        }

        public Vector3 GetLastRotation()
        {
            return _lastRotation;
        }

        public float GetVertical()
        {
            return _joystick.Vertical;
        }

        public Vector3 GetMaxScale()
        {
            return new Vector3(_maxScale, _maxScale, transform.localScale.z);
        }

        public Vector3 GetMinScale()
        {
            return new Vector3(_minScale, _minScale, transform.localScale.z);
        }

        public float GetScaleSpeed()
        {
            return _scaleSpeed;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        public bool GetTapTapStatue()
        {
            return _isTap;
        }

        public void SetScale(float value)
        {
            _maxScale = value;
        }

        public void SetSpeed(float value)
        {
            _speed= value;
        }

        #endregion
    }
}
