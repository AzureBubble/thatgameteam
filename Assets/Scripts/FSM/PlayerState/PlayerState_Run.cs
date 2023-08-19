using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/Run"), fileName = ("PlayerState_Run"))]
public class PlayerState_Run : PlayerState
{
    [SerializeField] private float moveSpeed = 5f;

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void LogicUpdate()
    {
        if (!input.isMove)
        {
            fsm.SwitchState(typeof(PlayerState_Idle));
        }

        if (input.isJump)
        {
            fsm.SwitchState(typeof(PlayerState_Jump));
        }

        if (!player.isGround)
        {
            fsm.SwitchState(typeof(PlayerState_CoyoteTime));
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