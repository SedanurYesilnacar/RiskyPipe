namespace RiskyPipe3D.UIs
{
    using System;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class BtnNextLevel : MonoBehaviour, IPointerDownHandler
    {
        private void Awake()
        {
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
            OnGameStateChanged(GameState.Pause);
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState.Equals(GameState.Win))
            {
                gameObject.SetActive(true);
                
            }
            else
            {
                gameObject.SetActive(false);
            }
                
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            EventManager.Instance.GameStateChange(GameState.NextStage);
        }
    }
}
