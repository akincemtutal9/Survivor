using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private EnemySO enemySO;
    void Start()
    {
        health = enemySO.health;
        maxHealth = enemySO.maxHealth;
        health = maxHealth;
    }
}
