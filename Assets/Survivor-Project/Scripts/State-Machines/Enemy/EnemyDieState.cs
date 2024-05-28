public class EnemyDieState : EnemyBaseState
{
    public EnemyDieState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.DestroyEnemyObject();
        stateMachine.DropExperiencePoints();
    }
    public override void Tick(float deltaTime)
    {

    }
    public override void Exit()
    {

    }
}