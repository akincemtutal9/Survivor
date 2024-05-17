using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public SkillData skillData;
    private IMovementStrategy movementStrategy;

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        movementStrategy = strategy;
    }

    protected virtual void Update() 
    {
        movementStrategy?.Move(transform,skillData.speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().DealDamage(skillData.damage);
            Destroy(gameObject, 2);
        }
    }
}
