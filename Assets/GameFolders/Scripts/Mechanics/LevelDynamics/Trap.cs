using RiskyPipe3D.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
public class Trap : MonoBehaviour
    {
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetScale(float scale)
        {
            transform.localScale = new Vector3(scale, scale, transform.localScale.z);
        }

        private void OnCollisionEnter(Collision collision)
        {
            
        }

        public void SetRotation(PipeType pipeType)
        {
            if (pipeType.Equals(PipeType.Vertical))
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
            }
            else
            {
                transform.rotation = Quaternion.Euler(90 * Vector3.up);
            }
        }
    }

}
