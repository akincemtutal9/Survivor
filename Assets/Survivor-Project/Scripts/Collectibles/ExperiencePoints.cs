using UnityEngine;

public class ExperiencePoints : MonoBehaviour, ICollectible
{
    public int experiencePoints = 1;
    public void Collect()
    {
        if (GameManager.Instance != null && GameManager.Instance.playerLevel != null)
        {
            GameManager.Instance.playerLevel.GainXP(experiencePoints);
        };
        Destroy(gameObject);
    }
}

