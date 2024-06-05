using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SkillData;

public class SkillCaster : MonoBehaviour
{
    private readonly int CastSkillHash = Animator.StringToHash("CastSkill");

    [SerializeField] private List<Skill> availableSkills; // Skill prefabs list
    [SerializeField] private Animator animator;
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
        if(GameStates.gameState.Equals(GameStates.GameState.Pause))
        {
            return;
        }
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
        if(skillPrefab.skillData.skillType == SkillType.Spin)
        {
            Instantiate(skillPrefab, transform.position, transform.rotation, transform);
        }
        else
        {
            HandleCastSkillAnimation();
            Instantiate(skillPrefab, transform.position, transform.rotation);
        }
        skillCooldowns[skillPrefab] = false;
        ResetCooldown(skillPrefab);
    }
    private async void ResetCooldown<T>(T skill) where T : Skill
    {
        await Task.Delay((int)skill.skillData.skillCooldown * 1000);
        skillCooldowns[skill] = true;
    }
    private void HandleCastSkillAnimation()
    {
        animator.ResetTrigger(CastSkillHash);
        animator.SetTrigger(CastSkillHash);
    }
}