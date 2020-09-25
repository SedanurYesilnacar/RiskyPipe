using RiskyPipe3D.Enums;
using RiskyPipe3D.GameDynamics;
using UnityEngine;

namespace RiskyPipe3D
{
    public class LineBeginningCollider : MonoBehaviour,ICollisionEnterResponse
    {
        public void OnCollisionEnterResponse(PlayerController player)
        {
            player.ChangeMechanic(ScaleMechanic.None);
            player.SetScale(4f);
        }
    }

}
