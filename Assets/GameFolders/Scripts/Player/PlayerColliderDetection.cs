using RiskyPipe3D.GameDynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D
{
    [DisallowMultipleComponent, RequireComponent(typeof(Rigidbody))]
    public class PlayerColliderDetection : MonoBehaviour
    {
        private PlayerController _playerController;

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
        }
        private void OnTriggerEnter(Collider collider)
        {
            IColliderEnterResponse colliderEnterResponse = collider.gameObject.GetComponent<IColliderEnterResponse>();
            colliderEnterResponse?.OnColliderEnterResponse(_playerController);
        }

        //private void OnTriggerStay(Collider collision)
        //{
        //    ICollisionStayResponse collisionStayResponse = collision.gameObject.GetComponent<ICollisionStayResponse>();
        //    collisionStayResponse?.OnCollisionStayResponse(_playerController);
        //}

        //private void OnTriggerExit(Collider collision)
        //{
        //    ICollisionExitResponse collisionExitResponse = collision.gameObject.GetComponent<ICollisionExitResponse>();
        //    collisionExitResponse?.OnCollisionExitResponse(_playerController);
        //}
    }

}
