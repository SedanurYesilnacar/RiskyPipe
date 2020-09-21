using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
    public class TrapFactory
    {
        public static TrapFactory Instance { get; private set; } = new TrapFactory();

        private List<Trap> _traps;


        private TrapFactory()
        {
            _traps = new List<Trap>();
            GameObject[] gameObjects = Resources.LoadAll<GameObject>("Traps");
            foreach(GameObject obj in gameObjects)
            {
                _traps.Add(obj.GetComponent<Trap>());
            }
        }

        public Trap GetTrap()
        {
            return _traps[0];
        }
    }
}
