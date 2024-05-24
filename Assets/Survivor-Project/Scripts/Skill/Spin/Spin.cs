using UnityEngine;
public class Spin : Skill
{
    protected override IMovementStrategy GetMovementStrategy()
    {
        return new SpinMovement();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().DealDamage(10);
        }
    }
}
