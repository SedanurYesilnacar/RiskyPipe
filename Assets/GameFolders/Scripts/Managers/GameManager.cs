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
        public static GameManager Instance;
        [SerializeField] private Color[] _pipeColors=null;
        [SerializeField] private Material _pipeMaterial=null;
        public bool _isRestaring = false;


        private void Awake()
        {
            Instance = this;
            Game.Instance.LoadGame();
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
        }

        private void Start()
        {
            SetRandomPipeColor();
        }

        public void SetRandomPipeColor()
        {
            _pipeMaterial.color = _pipeColors[UnityEngine.Random.Range(0, _pipeColors.Length)];
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
                    SetRandomPipeColor();
                    _isRestaring = true;
                    //Game.Instance.NextLevel(true);

                    break;
                case GameState.Win:

                    break;
                case GameState.Lose:
                    break;
                case GameState.NextStage:
                    Game.Instance.NextLevel();
                    
                    break;
            }
        }


        public void GameOverPanel(bool isActive)
        {
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
