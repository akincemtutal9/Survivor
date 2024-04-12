using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [field:SerializeField]
    public EnemySO EnemyData { get; private set; }

    [field: SerializeField]
    public EnemyHealth Health { get; private set; }

    [field: SerializeField]
    public PlayerHealth Player { get; private set; }

    [field: SerializeField]
    public NavMeshAgent Agent { get; private set; }

    [field: SerializeField]
    public CharacterController Controller { get; private set; }

    [field: SerializeField]
    public ForceReceiver ForceReceiver { get; private set; }



    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag(nameof(Player)).GetComponent<PlayerHealth>();
        //Agent.updatePosition = false;
        //Agent.updateRotation = false;
        SwitchState(new EnemyChaseState(this));
    }

    private void OnEnable()
    {
        Health.OnDie += HandleDie;
        Health.OnTakeDamage += HandleTakeDamage;
    }

    private void OnDisable()
    {
        Health.OnDie -= HandleDie;
        Health.OnTakeDamage -= HandleTakeDamage;
    }

    private void HandleDie()
    {
        //SwitchState(new EnemyDieState(this));
    }

    private void HandleTakeDamage()
    {
        //SwitchState(new EnemyTakeDamageState(this));
    }

}
