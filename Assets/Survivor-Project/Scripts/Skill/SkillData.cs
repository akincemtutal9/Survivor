using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "SkillData/SkillData", order = 1)]
public class SkillData : ScriptableObject
{
    public string skillName;
    public float skillCooldown;
    public int damage;
    public int speed;
}