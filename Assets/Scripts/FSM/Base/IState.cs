public interface IState
{
    void OnEnter();
    void LogicUpdate();
    void PhysicsUpdate();
    void OnExit();
}
