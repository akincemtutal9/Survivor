using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public SkillData skillData;
    public new Rigidbody rigidbody;
    private IMovementStrategy movementStrategy;
    protected abstract IMovementStrategy GetMovementStrategy();
    private void OnEnable()
    {
        Destroy(gameObject, 2);
    }
    protected virtual void Start()
    {
        movementStrategy = GetMovementStrategy();
        movementStrategy?.Move(rigidbody, transform, skillData.speed);
    }
}