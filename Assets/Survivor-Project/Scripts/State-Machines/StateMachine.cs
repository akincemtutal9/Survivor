using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState; // holds current state

    // Update is called once per frame
    void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }
    public void SwitchState(State newState)
    {
        currentState?.Exit();// make null check else how do you know which state to exit

        currentState = newState;

        currentState?.Enter();// we just give newState but always check if isNull?
    }

}