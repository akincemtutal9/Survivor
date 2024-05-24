using DG.Tweening;
using UnityEngine;

public class ExperiencePoints : MonoBehaviour, ICollectible
{
    public void Collect()
    {
        Debug.Log("Experience Points Collected");
        Destroy(gameObject);
    }
}

