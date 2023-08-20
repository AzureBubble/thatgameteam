using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/Idle"), fileName = ("PlayerState_Idle"))]
public class PlayerState_Idle : PlayerState
{
    public override void OnEnter()
    {
        base.OnEnter();
        player.SetVolictyX(0f);
    }

    public override void LogicUpdate()
    {
        if (input.isMove)
        {
            fsm.SwitchState(typeof(PlayerState_Run));
        }

        if (input.isJump || input.hasJumpInputBuffer)
        {
            fsm.SwitchState(typeof(PlayerState_Jump));
        }

        if (input.isAttack && player.canAttack)
        {
            fsm.SwitchState(typeof(PlayerState_Launch));
        }
        if (player.victory && player.isGround)
        {
            fsm.SwitchState(typeof(PlayerState_Victory));
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}