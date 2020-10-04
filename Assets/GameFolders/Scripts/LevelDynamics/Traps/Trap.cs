using RiskyPipe3D.Enums;
using RiskyPipe3D.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
public abstract class Trap : EnvironmentObject
    {
        public abstract void SetScale();
        

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.CompareTag("Player"))
            {
                EventManager.Instance.GameStateChange(GameState.Lose);
            }
        }
    }

}
