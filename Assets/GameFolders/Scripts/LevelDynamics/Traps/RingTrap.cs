using RiskyPipe3D.Enums;
using RiskyPipe3D.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
    public class RingTrap : Trap
    {
        public override void SetScale()
        {
            float scale = Random.Range(3, 10);
            transform.localScale = new Vector3(scale, scale, transform.localScale.z);
        }

    }

}
