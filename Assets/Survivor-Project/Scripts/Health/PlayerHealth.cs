using UnityEngine;
public class PlayerHealth : Health
{
    [SerializeField] private PlayerSO playerSO;
    private void Start()
    {
        health = playerSO.health;
        maxHealth = playerSO.maxHealth;
        health = maxHealth;
    }
}
