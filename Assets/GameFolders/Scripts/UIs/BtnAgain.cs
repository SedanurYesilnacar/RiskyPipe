namespace RiskyPipe3D.UIs
{
    using System;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class BtnAgain : MonoBehaviour, IPointerDownHandler
    {
        private void Awake()
        {
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
            gameObject.transform.parent.gameObject.SetActive(false);
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if(gameState.Equals(GameState.Lose))
            {
                gameObject.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            EventManager.Instance.GameStateChange(GameState.Restart);
        }
    }
}
