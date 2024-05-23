using UnityEngine;

public class Swing : Skill
{
    protected override IMovementStrategy GetMovementStrategy()
    {
        return new SwingMovement();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().DealDamage(10);
        }
    }

}
