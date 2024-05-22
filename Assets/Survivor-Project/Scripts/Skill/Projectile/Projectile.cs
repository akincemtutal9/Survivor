using UnityEngine;

public class Projectile : Skill
{
    private void Start()
    {
        SetMovementStrategy(new ProjectileMovement());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().DealDamage(skillData.damage);
        }
    }
}
