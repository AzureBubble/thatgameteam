using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/DoubleJump"), fileName = ("PlayerState_DoubleJump"))]
public class PlayerState_DoubleJump : PlayerState
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;

    public override void OnEnter()
    {
        base.OnEnter();
        player.SetVolictyY(jumpForce);
        player.doubleJump = false;
    }

    public override void LogicUpdate()
    {
        //input.stopJump ||
        if (player.isFalling)
        {
            fsm.SwitchState((typeof(PlayerState_Fall)));
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
        base.OnExit();
    }
}