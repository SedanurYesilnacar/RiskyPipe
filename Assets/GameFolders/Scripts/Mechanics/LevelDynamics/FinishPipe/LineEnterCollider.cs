using RiskyPipe3D.Enums;
using RiskyPipe3D.GameDynamics;
using UnityEngine;

namespace RiskyPipe3D
{
    public class LineEnterCollider : MonoBehaviour, ICollisionEnterResponse
    {
        public void OnCollisionEnterResponse(PlayerController player)
        {
            player.ChangeMechanic(ScaleMechanic.TapTap);
            player.SetSpeed(5f);

        }
    }

}
