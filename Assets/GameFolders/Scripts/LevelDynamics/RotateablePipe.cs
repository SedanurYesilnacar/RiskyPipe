using RiskyPipe3D.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
    public class RotateablePipe : BasePipe
    {
        public void SetRotation(Direction direction)
        {
            if (direction.Equals(Direction.Forward))
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
                return;
            }
            transform.rotation = Quaternion.Euler((direction == Direction.Right ? 90 : -90) * Vector3.up);

        }
    }
}
