using UnityEngine;

public class BombMovement : IMovementStrategy
{
    public void Move(Transform transform, int speed)
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("Enemy"));

        if (enemies.Length > 0)
        {
            Vector3 direction = (enemies[0].transform.position - transform.position).normalized * -1;
            transform.Translate((Vector3.up + direction).normalized * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate((Vector3.up) * Time.deltaTime * speed);
        }
    }
}
