using UnityEngine;

public class BombMovement : IMovementStrategy
{
    public void Move(Rigidbody rb, Transform transform, int speed)
    {
        Vector3 throwDirection = transform.forward * speed + transform.up * speed;
        rb.AddForce(throwDirection, ForceMode.VelocityChange);
    }
}