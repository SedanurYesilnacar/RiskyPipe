namespace RiskyPipe3D.Scripts.Managers
{
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.LevelDynamics;

    public class EventManager
    {
        #region Singleton
        public static EventManager Instance { get; private set; } = new EventManager();
        private EventManager() { }
        #endregion

        public delegate void OnMechanicChanged(ScaleMechanic scaleMechanic);
        public event OnMechanicChanged MechanicChanged;
        public void MechanicChange(ScaleMechanic scaleMechanic) => MechanicChanged?.Invoke(scaleMechanic);

        public delegate void OnGameStateChanged(GameState gameState);
        public event OnGameStateChanged GameStateChanged;
        public void GameStateChange(GameState gameState) => GameStateChanged?.Invoke(gameState);

        public delegate void OnMultipierSetted(int multipier);
        public event OnMultipierSetted MultipierSetted;
        public void MultipierSet(int multipier) => MultipierSetted?.Invoke(multipier);

        public delegate void OnScoreChanged(int totalScore);
        public event OnScoreChanged ScoreChanged;
        public void ScoreChange(int totalScore) => ScoreChanged?.Invoke(totalScore);

        public delegate void OnScoreIncreased();
        public event OnScoreIncreased ScoreIncreased;
        public void ScoreIncrease() => ScoreIncreased?.Invoke();

        public delegate void OnPipeDeActivated(BasePipe pipe);
        public event OnPipeDeActivated PipeDeActivated;
        public void PipeDeActivate(BasePipe pipe) => PipeDeActivated?.Invoke(pipe);

    }
}
