using RiskyPipe3D.LevelDynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace RiskyPipe3D.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
            

        [SerializeField] private List<BaseObject> _baseObjects;
        BaseObject[] BaseObjectsArray;
        public List<BaseObject> baseObjects
        {
            get => _baseObjects;
        }

        private void Awake()
        {
            SetUpBaseObjects();
            SetSingleton();
            CallBaseObjectsAwake();
        }

       
        private void Start()
        {
            CallBaseObjectsStart();
        }
        
        private void SetSingleton()
        {
            if (Instance == null) { Instance = this; }
            else { Debug.Log("Warning: multiple " + this + " in scene!"); }
        }

        private void SetUpBaseObjects()
        {
            BaseObjectsArray = FindObjectsOfType<BaseObject>();

            for (int i = 0; i < BaseObjectsArray.Length; i++)
            {
                if (!_baseObjects.Contains(BaseObjectsArray[i]))
                {
                    _baseObjects.Add(BaseObjectsArray[i]);
                }
                
            }
        }
        private void CallBaseObjectsAwake()
        {
            foreach (var e in _baseObjects)
            {
                e.PreInit();
            }
        }
        private void CallBaseObjectsStart()
        {
            foreach (var e in _baseObjects)
            {
                e.Init();
            }
        }
        public void SetCameraFollowTransform(Transform transform)
        {
            
            var cm = GetManager<CameraManager>();
            cm.SetCamFollow(transform);
        }

        public T GetManager<T>() where T : BaseObject
        {
            
            foreach (BaseObject e in _baseObjects)
            {
                if(e as T)
                {
                    return (T)Convert.ChangeType(e, typeof(T));
                }

            }
           return (T)Convert.ChangeType(_baseObjects[0], typeof(T));
        }

    }
}
