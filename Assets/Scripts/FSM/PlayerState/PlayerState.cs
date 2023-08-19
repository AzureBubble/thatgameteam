using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [Header("×´Ì¬¶¯»­ÐÅÏ¢")]
    [SerializeField] private string stateName;

    [SerializeField] private float transitionDuration = 0.1f;
    private int stateHash;

    protected PlayerController player;
    protected PlayerInput input;
    protected Animator animator;
    protected PlayerFSM fsm;
    protected float currentInfoTime => animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    protected float currentAnimationTime => currentInfoTime * animator.GetCurrentAnimatorStateInfo(0).length;
    protected bool isAnimationFinished => currentAnimationTime > 0.95f;

    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    public void Init(PlayerController player, PlayerInput input, Animator animator, PlayerFSM fsm)
    {
        this.player = player;
        this.input = input;
        this.animator = animator;
        this.fsm = fsm;
    }

    public virtual void OnEnter()
    {
        animator.CrossFade(stateHash, transitionDuration);
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