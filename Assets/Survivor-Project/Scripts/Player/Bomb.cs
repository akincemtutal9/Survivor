
public class Bomb : Skill
{
    private void Start()
    {
         SetMovementStrategy(new BombMovement());
    }
}
