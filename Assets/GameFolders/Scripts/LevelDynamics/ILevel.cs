namespace RiskyPipe3D.LevelDynamics
{
    public interface ILevel
    {
        void Initialize();
        void LoadLevel();
        void EndLevel();
        void RestartLevel();
    }
}
