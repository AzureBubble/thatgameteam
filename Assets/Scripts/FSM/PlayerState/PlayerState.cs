using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected PlayerController player;
    protected PlayerInput input;
    protected Animator animator;
    protected PlayerFSM fsm;

    public void Init(PlayerController player, PlayerInput input, Animator animator, PlayerFSM fsm)
    {
        this.player = player;
        this.input = input;
        this.animator = animator;
        this.fsm = fsm;
    }

    public virtual void OnEnter()
    {
        //animator.CrossFade();
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void OnExit()
    {
    }
}