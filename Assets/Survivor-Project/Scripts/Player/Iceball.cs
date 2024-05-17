using UnityEngine;

public class Iceball : Skill
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().DealDamage(skillData.damage);
            Destroy(gameObject, 2);
        }
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
    }
}
