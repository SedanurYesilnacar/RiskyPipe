using RiskyPipe3D.Enums;
using RiskyPipe3D.GameDynamics;
using UnityEngine;

namespace RiskyPipe3D
{
    public class LineBeginningCollider : MonoBehaviour,IColliderEnterResponse
    {
        public void OnColliderEnterResponse(PlayerController player)
        {
            player.ChangeMechanic(ScaleMechanic.None);
            player.SetScale(0.4f);
            player.SetSpeed(0.6f);
        }
    }

}
