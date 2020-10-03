namespace RiskyPipe3D.Enums
{
    public enum ScaleMechanic
    {
        None,
        TapTap,
        Joystick
    }

    public enum GameState
    {
        Playing,
        Win,
        NextStage,
        Lose,
        Pause,
        Restart
    }

    public enum Direction
    {
        Right,
        Left,
        Forward,
        Back,
        None
    }
    
    public enum PipeType
    {
        RightHorizontal,
        LeftHorizontal,
        Vertical,
        LeftVertical,
        RightVertical,
        VerticalLeft,
        VerticalRight,
        FinishPipe,
        PointPipe
    }

    public enum EnvironmentType
    {
        Trap,
        Energy,
        RingTrap
    }

}
