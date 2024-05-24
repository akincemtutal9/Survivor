using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Player/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    [Header("Combat Data")]
    public int health;
    public int maxHealth;
    public int damage;
    public float moveSpeed;

    [Header("Magnet")]
    public float collectibleArea;

}
