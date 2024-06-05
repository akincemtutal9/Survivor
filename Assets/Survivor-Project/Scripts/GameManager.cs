using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("References")]
    public PlayerLevel playerLevel;
    public SkillCaster skillCaster;

    [Header("Game UI's")]
    public Canvas skillCanvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        skillCanvas.gameObject.SetActive(false);
        GameStates.ResumeGame();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        skillCanvas.gameObject.SetActive(true);
        GameStates.PauseGame();
    }
}
