namespace RiskyPipe3D
{
    using RiskyPipe3D.LevelDynamics;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;

    public class Game : IGame
    {
        public static IGame Instance { get; private set; } = new Game();
        public PlayerView PlayerView { get; private set; }
        private ILevel _currentLevel;
        public int Level { get; set; }

        private Game()
        {
            PlayerView = FileManager.Instance.GetPlayer();
        }
        public void LoadGame()
        {
            _currentLevel = new Level(PlayerView.Level);
            _currentLevel.Initialize();
            _currentLevel.LoadLevel();
        }
        public void EndGame()
        {
            Application.Quit();
        }
        public void PuaseGame()
        {
        }
        public void StartGame()
        {
        }

        public void NextLevel()
        {
            PlayerView.Level += 1;
            _currentLevel.EndLevel();
            LoadGame();
        }

        public void RestartLevel()
        {
            _currentLevel.RestartLevel();
   
        }

        public void PauseGame()
        {
        }

        public PlayerView GetPlayer()
        {
            return PlayerView;
        }


    }
}
