using RiskyPipe3D.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
    public class RotateablePipe : Pipe
    {
        public void SetRotation(Direction direction)
        {
            Direction = direction;
            if (direction.Equals(Direction.Forward))
            {
                return;
            }
            transform.rotation = Quaternion.Euler((direction == Direction.Right ? 90 : -90) * Vector3.up);

        }
    }
}
