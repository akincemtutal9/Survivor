
public static class GameStates 
{
    public static bool isGamePaused = false;
    public static GameState gameState = GameState.Game;
    public static void PauseGame()
    {
        isGamePaused = true;
        gameState = GameState.Pause;
    }
    public static void ResumeGame()
    {
        isGamePaused = false;
        gameState = GameState.Game;
    }
    public enum GameState
    {
        Game,
        Pause
    }
}

