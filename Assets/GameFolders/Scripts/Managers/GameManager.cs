using RiskyPipe3D.LevelDynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RiskyPipe3D
{
    public class GameManager : MonoBehaviour
    {
        private Level _level;
        [SerializeField] private int _levelSize;

        private void Awake()
        {
            _level = new Level(_levelSize);
            _level.Initialize();
        }

        private void Start()
        {
            _level.LoadLevel();
            //_level.LoadTraps();
        }

    }
}
