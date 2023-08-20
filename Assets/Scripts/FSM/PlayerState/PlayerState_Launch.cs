using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/Launch"), fileName = ("PlayerState_Launch"))]
public class PlayerState_Launch : PlayerState
{
    public override void OnEnter()
    {
        base.OnEnter();
        player.SetVolictyX(0f);
    }

    public override void LogicUpdate()
    {
        if (isAnimationFinished)
        {
            player.launch.LaunchObj(-player.gameObject.transform.localScale.x);

            if (input.isMove)
            {
                fsm.SwitchState(typeof(PlayerState_Run));
            }
            else
            {
                fsm.SwitchState(typeof(PlayerState_Idle));
            }

            if (input.isJump || input.hasJumpInputBuffer)
            {
                fsm.SwitchState(typeof(PlayerState_Jump));
            }
            else
            {
                fsm.SwitchState(typeof(PlayerState_Idle));
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
        player.canAttack = false;
    }
}