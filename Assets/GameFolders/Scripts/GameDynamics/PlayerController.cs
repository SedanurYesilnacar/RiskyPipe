namespace RiskyPipe3D.GameDynamics
{
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class PlayerController : MonoBehaviour, IRotate, IScaleVertical, IScaleTapTap, IMove, IScaleNone
    {
        [SerializeField] private float _defaultSpeed = .5f;
        public float _speed;
        [SerializeField] private float _turnSpeed = 10f;
        [SerializeField] private float _scaleSpeed = .1f;
        [SerializeField] private float _maxScale = 2f;
        [SerializeField] private float _minScale = 1f;


        Rigidbody _rigidbody;

        private bool _isTap;

        private ICommand _moveForward;

        private Direction _direction = Direction.Forward;
        private ICommand _rotation;

        private ScaleMechanic _mechanic;
        
        private Dictionary<ScaleMechanic, ICommand> _mechanics;
        private Joystick _joystick;

        private Transform _centerObject;

        private float _rotateValue;

        private Vector3 _startingPosition;

        PlayerView playerView;

        // last rotation because must know before _rotation.Execute()
        private Vector3 _lastRotation = Vector3.zero;
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _startingPosition = transform.position;
            _rigidbody = GetComponent<Rigidbody>();
            _joystick = FindObjectOfType<Joystick>();
            _rotation = new Rotate(this);
            _mechanics = new Dictionary<ScaleMechanic, ICommand>();
            _moveForward = new MoveForward(this);
            _mechanics.Add(ScaleMechanic.Joystick, new ScaleJoystick(this));
            _mechanics.Add(ScaleMechanic.TapTap, new ScaleTapTap(this));
            _mechanics.Add(ScaleMechanic.None, new ScaleNone(this));
            EventManager.Instance.MechanicChanged += OnMechanicChanged;
            OnMechanicChanged(ScaleMechanic.Joystick);
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
            EventManager.Instance.PlayerGot += OnPlayerGot;
        }

        private void OnPlayerGot(PlayerView playerView)
        {
            this.playerView = playerView;
            _defaultSpeed = playerView.DefaultSpeed;
            playerView.SpeedChanged += OnSpeedChanged;
        }

        private void OnSpeedChanged(float defaultSpeed)
        {
            _defaultSpeed = defaultSpeed;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if(gameState.Equals(GameState.Playing))
            {
                SpeedUp();
            }else if (gameState.Equals(GameState.Restart))
            {
                _mechanic = ScaleMechanic.Joystick;
                transform.rotation = Quaternion.identity;
                SetPosition(_startingPosition);
                SpeedDown();

            }
            else if (gameState.Equals(GameState.NextStage))
            {
                _mechanic = ScaleMechanic.Joystick;
                transform.rotation = Quaternion.identity;
                SetPosition(_startingPosition);
            }
            else
            {
                SpeedDown();
            }
        }

        private void OnMechanicChanged(ScaleMechanic scaleMechanic)
        {
            switch (scaleMechanic)
            {
                case ScaleMechanic.Joystick:
                    break;
                case ScaleMechanic.TapTap:
                    EventManager.Instance.EnergyChange(false);
                    EventManager.Instance.TapTapChange(true);
                    break;
                default:
                    EventManager.Instance.TapTapChange(false);
                    break;
            }
            _mechanic = scaleMechanic;
        }

        private void FixedUpdate()
        {
            _moveForward.Execute();
        }

        private void Update()
        {
            ScaleIt();
            if (_mechanic.Equals(ScaleMechanic.TapTap) && Input.GetMouseButtonDown(0))
            {
                _isTap = true;
            }
            else
            {
                _isTap = false;
            }
        }

        private void ScaleIt()
        {
            if(_mechanics.ContainsKey(_mechanic))
                _mechanics[_mechanic].Execute();
        }

        public void IncreaseScore()
        {
            EventManager.Instance.ScoreChange(1);
        }

        public void Rotate()
        {
            _rotation.Execute();
            _rotateValue = transform.rotation.eulerAngles.y;
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
            _speed = 0f;
        }

        public void SpeedUp()
        {
            _speed = _defaultSpeed;
        }
        
        public void SetCenterObject(Transform centerObj)
        {
            _centerObject = centerObj;
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
            return new Vector3(_maxScale, _maxScale, _maxScale);
        }

        public Vector3 GetMinScale()
        {
            return new Vector3(_minScale, _minScale, _minScale);
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

        public Vector3 GetCenterObject()
        {
            return _centerObject.position;
        }

        public Direction GetDirection()
        {
            return _direction;
        }

        #endregion
    }
}
