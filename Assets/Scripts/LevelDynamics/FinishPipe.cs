using RiskyPipe3D.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
    public class FinishPipe : Pipe
    {
        public void SetRotation(Direction direction)
        {
            if(direction.Equals(Direction.Forward))
            {
                return;
            }
            transform.rotation = Quaternion.Euler((direction == Direction.Right ? 90 : -90) * Vector3.up);
         
        }
    }
}

