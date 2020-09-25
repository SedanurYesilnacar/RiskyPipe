using UnityEngine;
using RiskyPipe3D.GameDynamics;
using RiskyPipe3D.Managers;

namespace RiskyPipe3D
{
    public class ScoreMultiplierCollider : MonoBehaviour, IColliderEnterResponse
    {
       public void OnColliderEnterResponse(PlayerController player)
        {
            GameManager.Instance.GetManager<PlayerManager>().IncreaseScoreMultiplier();
        }
    }
}

