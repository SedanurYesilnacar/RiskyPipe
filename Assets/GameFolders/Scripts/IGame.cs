namespace RiskyPipe3D
{
    public interface IGame
    {
        PlayerView GetPlayer();
        void LoadGame();
        void StartGame();
        void NextLevel(bool value);
        void RestartLevel();
        void PauseGame();
        void EndGame();
    }
}
