namespace RiskyPipe3D.UIs
{
    using System;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    using UnityEngine.EventSystems;
    public class BtnGamePlayStart : MonoBehaviour, IPointerDownHandler
    {

        

        private void Start()
        {
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState.Equals(GameState.Pause) || gameState.Equals(GameState.NextStage) || gameState.Equals(GameState.Restart))
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            EventManager.Instance.GameStateChange(GameState.Playing);
            EventManager.Instance.EnergyChange(true);
            EventManager.Instance.TapTapChange(false);
        }
    }
}
