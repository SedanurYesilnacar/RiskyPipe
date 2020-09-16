
namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public interface IMove : ICommand
    {
        void Execute(Transform transform, float speed);
    }
}
