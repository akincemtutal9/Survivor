using UnityEngine;
using static SkillData;

public abstract class Skill : MonoBehaviour
{
    public SkillData skillData;
    private IMovementStrategy movementStrategy;

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        movementStrategy = strategy;
    }
    private void OnEnable()
    {
        Destroy(gameObject, 2);
    }
    protected virtual void Update() 
    {
        movementStrategy?.Move(transform,skillData.speed);
    }
}
