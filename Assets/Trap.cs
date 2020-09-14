using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D
{
    public class Trap : LevelObject
    {
        public override void SetObject(LevelObject levelObject = null)
        {
            transform.localPosition = Vector3.zero;
        }
    }

}
