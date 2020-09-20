using RiskyPipe3D.LevelDynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RiskyPipe3D
{
    public class GameManager : MonoBehaviour
    {
        private Level _level;

        private void Awake()
        {
            _level = new Level(50);
            _level.Initialize();
        }

        private void Start()
        {
            _level.LoadLevel();
        }

    }
}
