using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RiskyPipe3D.Managers
{
    public class CameraManager : BaseObject
    {
        [SerializeField] Cinemachine.CinemachineVirtualCamera camera;

        public override void PreInit()
        {
            if (camera == null)
            {
                camera = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
            }
        }

        public void SetCamFollow(Transform ring)
        {
            camera.Follow = ring;
            camera.LookAt = ring;
        }
    }
}


