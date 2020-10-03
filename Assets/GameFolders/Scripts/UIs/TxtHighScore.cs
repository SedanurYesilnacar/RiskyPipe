namespace RiskyPipe3D.UIs
{
    using System;
    using RiskyPipe3D;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public class TxtHighScore : MonoBehaviour
    {
        private Text _txtHighScore;
        private void Awake()
        {
            _txtHighScore = GetComponent<Text>();
            Game.Instance.GetPlayer().HighScoreChanged += OnHighScoreChanged;
            OnHighScoreChanged(Game.Instance.GetPlayer().HighScore);
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState.Equals(GameState.Pause) || gameState.Equals(GameState.NextStage) || gameState.Equals(GameState.Restart))
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }

        private void OnHighScoreChanged(int highScore)
        {
            _txtHighScore.text = "HighScore : " + highScore.ToString();
        }
    }
}
