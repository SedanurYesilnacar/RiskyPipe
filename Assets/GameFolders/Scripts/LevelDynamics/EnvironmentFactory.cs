using RiskyPipe3D.Enums;
using RiskyPipe3D.Scripts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RiskyPipe3D.LevelDynamics
{
    public class EnvironmentFactory
    {
        public static EnvironmentFactory Instance { get; private set; } = new EnvironmentFactory();

        private Dictionary<EnvironmentType, EnvironmentObject> _environmentPrefab;

        private Dictionary<EnvironmentType, Queue<EnvironmentObject>> _environmentPool;
        private EnvironmentFactory()
        {
            
            _environmentPrefab = new Dictionary<EnvironmentType, EnvironmentObject>();
            _environmentPool = new Dictionary<EnvironmentType, Queue<EnvironmentObject>>();
            GameObject[] gameObjects = Resources.LoadAll<GameObject>("Environments");
            foreach(GameObject obj in gameObjects)
            {
                EnvironmentObject environmentObject = obj.GetComponent<EnvironmentObject>();
                _environmentPrefab.Add(environmentObject.EnvironmentType, environmentObject);
            }
            EventManager.Instance.EnvironmentObjectDeactivated += OnEnvironmentObjectDeactivated;
        }

        private void OnEnvironmentObjectDeactivated(EnvironmentObject environmentObject)
        {
            if(_environmentPool.ContainsKey(environmentObject.EnvironmentType))
            {
                _environmentPool[environmentObject.EnvironmentType].Enqueue(environmentObject);
            }
            else
            {
                _environmentPool.Add(environmentObject.EnvironmentType, new Queue<EnvironmentObject>());
                _environmentPool[environmentObject.EnvironmentType].Enqueue(environmentObject);
            }
        }

        public EnvironmentObject GetEnvironmentObject(EnvironmentType environmentType)
        {
            if (environmentType.Equals(EnvironmentType.Trap))
            {
                environmentType = UnityEngine.Random.Range(0,2)==0?EnvironmentType.Trap:EnvironmentType.Trap2;
            }
            if(_environmentPool.ContainsKey(environmentType) && _environmentPool[environmentType].Count > 0)
            {
                return _environmentPool[environmentType].Dequeue();
            }
            else
            {
                return GetNewEnvironmentObject(environmentType);
            }
        }

        private EnvironmentObject GetNewEnvironmentObject(EnvironmentType environmentType)
        {
            return MonoBehaviour.Instantiate(_environmentPrefab[environmentType]);
        }
    }
}
