using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RiskyPipe3D.UIs
{
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using System;

    public class LevelText : MonoBehaviour
    {
        [SerializeField] private Text _textLevel=null;

        private void Awake()
        {
            Game.Instance.GetPlayer().LevelChanged += OnLevelChanged;
            OnLevelChanged(Game.Instance.GetPlayer().Level);
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
            gameObject.SetActive(false);
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if(gameState.Equals(GameState.Playing))
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void OnLevelChanged(int level)
        {
            _textLevel.text = "LEVEL " + level.ToString();
        }


        
    }
}

