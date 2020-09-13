using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RiskyPipe3D
{
    public class GameManager : MonoBehaviour
    {
        LevelFactory _levelFactory;
        Level _level;

        private void Awake()
        {
            _levelFactory = new LevelFactory();
            _level = _levelFactory.GetNewLevel(10);
            _level.LoadLevel();
            _level.StartLevel();
        }
    }
}
