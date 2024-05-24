public class EnemyDieState : EnemyBaseState
{
    public EnemyDieState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.DropExperiencePoints();
        stateMachine.DestroyEnemyObject();
    }
    public override void Tick(float deltaTime)
    {

    }
    public override void Exit()
    {

    }
}