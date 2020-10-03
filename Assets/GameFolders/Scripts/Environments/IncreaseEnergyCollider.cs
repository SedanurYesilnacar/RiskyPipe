using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RiskyPipe3D.Scripts.Managers;

namespace RiskyPipe3D.Environments
{
    public class IncreaseEnergyCollider : MonoBehaviour
    {
        private void OnTriggerStay(Collider collider)
        {
            if(collider.CompareTag("Player"))
            {
                EventManager.Instance.EnergyIncrease();
            }
        }
    }
}