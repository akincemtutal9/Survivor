using UnityEngine;
public class ProjectileMovement : IMovementStrategy
{
    public void Move(Transform transform,int speed)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
