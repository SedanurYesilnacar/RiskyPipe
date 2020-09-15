using UnityEngine;

namespace RiskyPipe3D.GameDynamics
{
    public class MoveForward : IMove
    {
        public void Execute(Transform transform, float speed)
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
        }
    }
}
