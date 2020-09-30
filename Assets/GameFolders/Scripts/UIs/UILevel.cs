namespace RiskyPipe3D.UIs
{
    using System;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    using UnityEngine.UI;


    public class UILevel : MonoBehaviour
    {
        private Text _txtLevel;
        void Awake()
        {
            _txtLevel = GetComponentInChildren<Text>();
            EventManager.Instance.LevelChanged += OnLevelChanged;
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState.Equals(GameState.Playing))
            {
                gameObject.SetActive(true);
            }
            else
                gameObject.SetActive(false);
        }

        private void OnLevelChanged(int level)
        {
            _txtLevel.text = "LEVEL "+level.ToString();
        }
    }
}
