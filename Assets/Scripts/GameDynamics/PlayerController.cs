namespace RiskyPipe3D.GameDynamics
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = .5f;
        [SerializeField] private float _turnSpeed = 10f;
        private IMove _moveForward;
        private Dictionary<Direction, IRotate> _rotations;

        private void Awake()
        {
            _rotations = new Dictionary<Direction, IRotate>();
            _moveForward = new MoveForward();
            _rotations.Add(Direction.Left, new RotateLeft());
            _rotations.Add(Direction.Right, new RotateRight());
        }
        bool b = false;
        private void FixedUpdate()
        {
            _moveForward.Execute(transform, _speed);
        }
        private IEnumerator Rotate(Direction direction)
        {
            var wait = new WaitForSeconds(.1f);
            _rotations[direction].SetToRotation(transform.rotation.eulerAngles);
            while(!_rotations[direction].Execute(transform, _turnSpeed))
            {
                yield return wait;
            }
        }

        public void Rotation(Direction direction)
        {
            StartCoroutine(Rotate(direction));
        }
    }
}
