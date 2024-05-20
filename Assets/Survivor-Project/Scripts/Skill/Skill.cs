using UnityEngine;
using static SkillData;

public abstract class Skill : MonoBehaviour
{
    public SkillData skillData;
    private IMovementStrategy movementStrategy;

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        movementStrategy = strategy;
    }
    private void OnEnable()
    {
        Destroy(gameObject, 2);
    }
    protected virtual void Update() 
    {
        movementStrategy?.Move(transform,skillData.speed);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(skillData.skillType != SkillType.Missile)
        {
            return;
        }
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().DealDamage(skillData.damage);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (skillData.skillType != SkillType.Bomb)
        {
            return;
        }
        Collider[] enemies = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("Enemy"));
        if (enemies.Length > 0)
        {
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyHealth>().DealDamage(skillData.damage);
                Destroy(gameObject);
            }
        }
    }
}
