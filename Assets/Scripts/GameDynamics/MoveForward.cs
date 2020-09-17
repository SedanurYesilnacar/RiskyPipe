using UnityEngine;

namespace RiskyPipe3D.GameDynamics
{
    public class MoveForward : ICommand
    {
        private IMove _move;
        public MoveForward(IMove move)
        {
            _move = move;
        }
        public void Execute()
        {
            _move.GetTransform().position += _move.GetTransform().transform.forward * _move.GetSpeed() * Time.fixedDeltaTime;
        }
    }
}
