using UnityEngine;

public class BombMovement : IMovementStrategy
{
    public void Move(Transform transform, int speed)
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
