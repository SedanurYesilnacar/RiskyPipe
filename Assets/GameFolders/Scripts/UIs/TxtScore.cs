namespace RiskyPipe3D.UIs
{
    using System;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public class TxtScore : MonoBehaviour
    {
        private Text _txtScore;
        private int totalScore;
        void Awake()
        {
            _txtScore = GetComponent<Text>();
            EventManager.Instance.ScoreIncreased += OnScoreIncreased;
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
            EventManager.Instance.MultipierSetted += OnMultipierSetted;
        }

        private void OnScoreIncreased()
        {
            this.totalScore++;
            _txtScore.text = totalScore.ToString();
        }

        private void OnMultipierSetted(int multipier)
        {
            _txtScore.text = multipier + " x " + totalScore + " = " + (totalScore * multipier);
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState.Equals(GameState.Playing) || gameState.Equals(GameState.Win))
            {
                gameObject.SetActive(true);
                
            
            }else if (gameState.Equals(GameState.Restart) || gameState.Equals(GameState.NextStage))
            {
                totalScore = -1;
                OnScoreIncreased();
                EventManager.Instance.ScoreReset();
            }
            else
                gameObject.SetActive(false);
        }
    }
}
