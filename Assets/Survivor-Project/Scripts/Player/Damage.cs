using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Damage : MonoBehaviour
{
    [SerializeField] private Fireball fireballPrefab; // Skill prefabs
    [SerializeField] private Iceball iceballPrefab; // Skill prefabs

    private Dictionary<Skill, bool> skillCooldowns = new Dictionary<Skill, bool>();

    private void Start()
    {
        // Initialize the cooldown dictionary
        skillCooldowns[fireballPrefab] = true;
        skillCooldowns[iceballPrefab] = true;
    }
    private void Update()
    {
        // Example of casting different skills
        if (skillCooldowns[fireballPrefab])
        {
            CastSkill(fireballPrefab);
        }

        if (skillCooldowns[iceballPrefab])
        {
            CastSkill(iceballPrefab);
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