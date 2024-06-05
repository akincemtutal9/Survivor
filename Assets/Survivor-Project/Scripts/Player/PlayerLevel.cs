using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerLevel : MonoBehaviour
{
    private int currentLevel = 1;
    private int currentXP = 0;
    private int xpToNextLevel = 4;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private Canvas skillCanvas;

    private void Start()
    {
        UpdateLevelUI();
        //skillCanvas.gameObject.SetActive(false); // Sahnede kapatýver baþýmýz aðrýmasýn :D
    }
    public void GainXP(int amount)
    {
        currentXP += amount;
        CheckLevelUp();
        UpdateLevelUI();
    }
    private void CheckLevelUp()
    {
        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            currentLevel++;
            xpToNextLevel = CalculateXPForNextLevel(currentLevel);
            OnLevelUp();
        }
    }

    private int CalculateXPForNextLevel(int level)
    {
        return Mathf.FloorToInt(10 * Mathf.Pow(1.5f, level - 1));
    }

    private void OnLevelUp()
    {
        Debug.Log("Level Up! Current Level: " + currentLevel);
        GameManager.Instance.PauseGame();
    }

    private void UpdateLevelUI()
    {
        if (levelText != null)
            levelText.text = "Level: " + currentLevel;
        if (xpSlider != null)
        {
            xpSlider.maxValue = xpToNextLevel;
            xpSlider.value = currentXP;
        }
    }
}
