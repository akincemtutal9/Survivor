using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
        stateMachine.Agent.ResetPath();
        stateMachine.Agent.velocity = Vector3.zero;
    }

    public override void Tick(float deltaTime)
    {

        if (IsInAttackRange())
        {
            //stateMachine.SwitchState(new EnemyAttackState(stateMachine));
            return;
        }
        FacePlayer();
        MoveToPlayer(deltaTime);
    }

    private void MoveToPlayer(float deltaTime)
    {
        if (stateMachine.Agent.isOnNavMesh)
        {
            stateMachine.Agent.destination = stateMachine.Player.transform.position;
            Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.EnemyData.moveSpeed, deltaTime);
        }
        stateMachine.Agent.velocity = stateMachine.Controller.velocity;

    }

    private bool IsInAttackRange()
    {
        if (stateMachine.Player.isDead) { return false; }

        var playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return playerDistanceSqr <= Mathf.Pow(stateMachine.EnemyData.attackRange, 2);
    }
}
