using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Enemy/EnemySO")]
public class EnemySO : ScriptableObject
{
    public int health;
    public int maxHealth;
    public int damage;
    public float moveSpeed;
    public float attackRange;
}
