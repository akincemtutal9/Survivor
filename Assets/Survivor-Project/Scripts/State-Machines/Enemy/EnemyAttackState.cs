using DG.Tweening;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float timer;
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        timer = 0;
        Debug.Log("EnemyAttackState");
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;
        if(timer > stateMachine.EnemyData.attackCooldown)
        {
            stateMachine.Player.DealDamage(stateMachine.EnemyData.damage);
            stateMachine.transform.DOScale(1.1f, 0.1f).OnComplete(() => stateMachine.transform.DOScale(1, 0.1f));
            timer = 0;
        }
        FacePlayer();
        if(!IsInAttackRange())
        {
            stateMachine.SwitchState(new EnemyChaseState(stateMachine));
        }   
    }
    public override void Exit()
    {

    }
}

