using RiskyPipe3D.Enums;
using RiskyPipe3D.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
public class Trap : EnvironmentObject
    {
        public void SetScale()
        {
            float scale = Random.Range(2, 7);
            transform.localScale = new Vector3(scale, scale, transform.localScale.z);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.CompareTag("Player"))
            {
                EventManager.Instance.GameStateChange(GameState.Lose);
            }
        }
    }

}
