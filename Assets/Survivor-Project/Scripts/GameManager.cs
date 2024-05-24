using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int experiencePoints { get; private set; }



    public static GameManager Instance { get; private set; }
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

    public void AddExperiencePoints(int amount)
    {
        experiencePoints += amount;
    }

}
