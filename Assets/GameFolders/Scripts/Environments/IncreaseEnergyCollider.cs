using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.Environments
{
    public class IncreaseEnergyCollider : MonoBehaviour
    {
        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("asfdad");
            }
        }
    }
}