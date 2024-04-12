public abstract class State //: MonoBehaviour This class won't need to be inherit Unity
{
    // Any State will have these method
    public abstract void Enter();
    //This method will be update of States it will be using time.deltatime
    public abstract void Tick(float deltaTime);
    public abstract void Exit();
}