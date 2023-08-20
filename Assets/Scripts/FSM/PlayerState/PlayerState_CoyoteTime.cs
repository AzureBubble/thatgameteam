using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/CoyoteTime"), fileName = ("PlayerState_CoyoteTime"))]
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float coyoteTime = 0.1f;

    public override void OnEnter()
    {
        base.OnEnter();
        player.SetGravity(0f);
    }

    public override void LogicUpdate()
    {
        if (input.isJump)
        {
            fsm.SwitchState(typeof(PlayerState_Jump));
        }

        if (currentAnimationTime > coyoteTime || !input.isMove)
        {
            fsm.SwitchState(typeof(PlayerState_Fall));
        }
        if (input.isAttack && player.canAttack)
        {
            fsm.SwitchState(typeof(PlayerState_Launch));
        }
    }

    public override void PhysicsUpdate()
    {
        player.Move(moveSpeed);
    }

    public override void OnExit()
    {
        player.SetGravity(1f);
    }
}