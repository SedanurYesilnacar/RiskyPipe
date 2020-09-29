using RiskyPipe3D.Enums;
using RiskyPipe3D.LevelDynamics;
using RiskyPipe3D.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RiskyPipe3D
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Game.Instance.LoadGame();
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Pause:
                    Game.Instance.PauseGame();
                    break;
                case GameState.Playing:
                    Game.Instance.StartGame();
                    break;
                case GameState.Restart:
                    Game.Instance.RestartLevel();
                    break;
                case GameState.Win:
                    
                    break;
                case GameState.Lose:
                    Game.Instance.RestartLevel();
                    break;
                case GameState.NextStage:
                    Game.Instance.NextLevel();
                    break;
            }
        }

        /*
        Playing,
        Win,
        Lose,
        Pause,
        Restart
         */
         
    }
}
