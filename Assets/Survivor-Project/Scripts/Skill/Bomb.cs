using UnityEngine;

public class Bomb : Skill
{
    [SerializeField] private GameObject explosionEffect;
    private void Start()
    {
        SetMovementStrategy(new BombMovement());
    }

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
    }
}
