using RiskyPipe3D.Enums;
using RiskyPipe3D.GameDynamics;
using UnityEngine;

namespace RiskyPipe3D
{
    public class LineExitCollider : MonoBehaviour, ICollisionEnterResponse
    {
        public void OnCollisionEnterResponse(PlayerController player)
        {
            player.ChangeMechanic(ScaleMechanic.None);
        }
    }

}
