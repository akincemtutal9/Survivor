
public static class GameStates 
{
    public static bool isGamePaused = false;
    public static void PauseGame()
    {
        isGamePaused = true;
    }
    public static void ResumeGame()
    {
        isGamePaused = false;
    }

   
}
