using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RiskyPipe3D.LevelDynamics;

namespace RiskyPipe3D.Managers
{
    public class LevelManager : BaseObject
    {
        [SerializeField] private int _levelSize;
        private Level _level;


        public override void PreInit()
        {
            _level = new Level(_levelSize);
            _level.Initialize();
        }
        public override void Init()
        {
            
            _level.LoadLevel();
            _level.LoadTraps();
        }
    }

}
