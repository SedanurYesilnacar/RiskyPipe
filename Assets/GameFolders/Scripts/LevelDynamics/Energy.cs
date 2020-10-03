
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
    public class Energy : EnvironmentObject
    {

        public void SetScale(int maxLength)
        {
            transform.localScale = new UnityEngine.Vector3(1.2f, 1.2f, Random.Range(1.2f,maxLength));
        }
    }
}
