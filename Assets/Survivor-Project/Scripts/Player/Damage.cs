using UnityEngine;
using System.Threading.Tasks;

public class Damage : MonoBehaviour
{
    [SerializeField] private SkillData skillData;
    private bool canDamage = true;
    private void Update()
    {
        if (canDamage)
        {
            var objs = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (var obj in objs)
            {
                obj.GetComponent<EnemyHealth>().DealDamage(skillData.damage);
            }
            canDamage = false;
            ResetCooldown();
        }
    }

    private async void ResetCooldown()
    {   
        await Task.Delay((int)skillData.skillCooldown * 1000);
        canDamage = true;
    }
    
}
