using UnityEngine;

public class Bomb : Skill
{
    [SerializeField] private GameObject explosionEffect;
    protected override IMovementStrategy GetMovementStrategy()
    {
        return new BombMovement();
    }
    public void OnCollisionEnter(Collision collision)
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("Enemy"));
        if (enemies.Length > 0)
        {
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyHealth>().DealDamage(skillData.damage);
            }
        }
        GameObject expEffect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(expEffect, 1);
        Destroy(gameObject);
    }
}