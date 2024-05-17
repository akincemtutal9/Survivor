using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Damage : MonoBehaviour
{
    [SerializeField] private List<Skill> availableSkills; // Skill prefabs list
    private Dictionary<Skill, bool> skillCooldowns = new Dictionary<Skill, bool>();
    private void Start()
    {
        // Initialize the cooldown dictionary for each skill in the availableSkills list
        foreach (var skill in availableSkills)
        {
            skillCooldowns[skill] = true;
        }
    }
    private void Update()
    {
        // Example of casting different skills from the availableSkills list
        foreach (var skill in availableSkills)
        {
            if (skillCooldowns[skill])
            {
                CastSkill(skill);
            }
        }
    }
    public void AddSkill(Skill skillPrefab)
    {
        if (!availableSkills.Contains(skillPrefab))
        {
            availableSkills.Add(skillPrefab);
            skillCooldowns[skillPrefab] = true;
        }
    }
    private void CastSkill<T>(T skillPrefab) where T : Skill
    {
        Instantiate(skillPrefab, transform.position, transform.rotation);
        skillCooldowns[skillPrefab] = false;
        ResetCooldown(skillPrefab);
    }

    private async void ResetCooldown<T>(T skill) where T : Skill
    {
        await Task.Delay((int)skill.skillData.skillCooldown * 1000);
        skillCooldowns[skill] = true;
    }
}