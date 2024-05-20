public class Iceball : Skill
{
    private void Start()
    {
        SetMovementStrategy(new ProjectileMovement());
    }
}
