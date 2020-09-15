
namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public interface IMove
    {
        void Execute(Transform transform, float speed);
    }
}
