using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/Fall"), fileName = ("PlayerState_Fall"))]
public class PlayerState_Fall : PlayerState
{
    [SerializeField] private float moveSpeed = 5f;

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void LogicUpdate()
    {
        if (player.isGround)
        {
            fsm.SwitchState((typeof(PlayerState_Idle)));
        }

        if (input.isJump)
        {
            if (player.doubleJump)
            {
                fsm.SwitchState((typeof(PlayerState_DoubleJump)));
                return;
            }

            input.SetJumpInputBufferTime();
        }

        if (input.isAttack && player.canAttack)
        {
            fsm.SwitchState(typeof(PlayerState_Launch));
        }

        if(player.victory&&player.isGround)
        {
            fsm.SwitchState(typeof(PlayerState_Victory));
        }
    }

    public override void PhysicsUpdate()
    {
        player.Move(moveSpeed);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}