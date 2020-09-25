using RiskyPipe3D.Enums;
using RiskyPipe3D.GameDynamics;
using UnityEngine;

namespace RiskyPipe3D
{
    public class LineEnterCollider : MonoBehaviour, IColliderEnterResponse
    {
        public void OnColliderEnterResponse(PlayerController player)
        {
            player.ChangeMechanic(ScaleMechanic.TapTap);
            player.SetSpeed(2f);
            player.SetMaxScale(8f);

        }
    }

}
