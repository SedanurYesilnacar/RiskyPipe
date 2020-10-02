namespace RiskyPipe3D.UIs
{
    using System;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class BtnAgain : MonoBehaviour, IPointerDownHandler
    {
       
        public void OnPointerDown(PointerEventData eventData)
        {
            
            GameManager.Instance.SetRandomPipeColor();
            GameManager.Instance.GameOverPanel(false);
            GameManager.Instance._isRestaring = true;
            EventManager.Instance.GameStateChange(GameState.NextStage);

        }
    }
}
