using UnityEngine;

public class Projectile : Skill
{
    protected override IMovementStrategy GetMovementStrategy()
    {
        return new ProjectileMovement();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().DealDamage(skillData.damage);
        }
    }
}
