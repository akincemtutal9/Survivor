public class Fireball : Skill
{
    private void Start()
    {
        SetMovementStrategy(new ProjectileMovement());
    }
}
