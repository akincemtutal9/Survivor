using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Player/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public int health;
    public int maxHealth;
    public int damage;
    public float moveSpeed;
}
