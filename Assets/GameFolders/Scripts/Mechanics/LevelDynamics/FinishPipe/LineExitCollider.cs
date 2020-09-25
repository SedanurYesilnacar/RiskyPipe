using RiskyPipe3D.Enums;
using RiskyPipe3D.GameDynamics;
using UnityEngine;

namespace RiskyPipe3D
{
    public class LineExitCollider : MonoBehaviour, IColliderEnterResponse
    {
        public void OnColliderEnterResponse(PlayerController player)
        {
            player.ChangeMechanic(ScaleMechanic.None);
          
        }
    }

}
