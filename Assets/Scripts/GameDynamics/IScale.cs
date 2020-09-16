namespace RiskyPipe3D.GameDynamics
{
    using UnityEngine;
    public interface IScale : ICommand
    {
        void Execute(Transform transform, float vertical);
    }
}
