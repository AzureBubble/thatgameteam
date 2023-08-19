using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/Jump"), fileName = ("PlayerState_Jump"))]
public class PlayerState_Jump : PlayerState
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;

    public override void OnEnter()
    {
        base.OnEnter();
        player.SetVolictyY(jumpForce);
        player.doubleJump = true;
    }

    public override void LogicUpdate()
    {
        if (input.stopJump)
        {
            fsm.SwitchState(typeof(PlayerState_Fall));
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