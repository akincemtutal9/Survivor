using UnityEngine;
using System.Linq;

public class FaceClosestEnemy : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private void FixedUpdate()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, 10f, LayerMask.GetMask("Enemy"));

        if (enemies.Length > 0)
        {
            Collider nearestEnemy = enemies.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();

            if (nearestEnemy != null)
            {
                Vector3 direction = nearestEnemy.transform.position - transform.position;

                direction.y = 0f;

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
