using UnityEngine;
public class EnemyTakeDamageState : EnemyBaseState
{
    private float duration = 1f;
    public EnemyTakeDamageState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * -1);
        stateMachine.HealthBar.fillAmount = (float)stateMachine.Health.health / stateMachine.Health.maxHealth;
    }
    public override void Tick(float deltaTime)
    {
        duration -= deltaTime;

        if (duration <= 0f)
        {
            stateMachine.SwitchState(new EnemyChaseState(stateMachine));
        }
    }
    public override void Exit()
    {

    }
}