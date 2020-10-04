using RiskyPipe3D.Enums;
using RiskyPipe3D.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
    public class NormalTrap : Trap
    {

        public override void SetScale()
        {
            float scale = Random.Range(2, 7);
            transform.localScale = new Vector3(scale, scale, transform.localScale.z);
            if (EnvironmentType.Equals(EnvironmentType.Trap2))
            {
                SetColor();
            }
            
        }
        private void SetColor()
        {
            GetComponent<MeshRenderer>().material.color = new Color(Random.value,Random.value,Random.value);

        }
    }

}
