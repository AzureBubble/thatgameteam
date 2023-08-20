using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/Jump"), fileName = ("PlayerState_Jump"))]
public class PlayerState_Jump : PlayerState
{
    [Header("ÕÊº“ Ù–‘")]
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private AudioClip SFX;

    public override void OnEnter()
    {
        input.hasJumpInputBuffer = false;
        base.OnEnter();
        player.SetVolictyY(jumpForce);
        player.doubleJump = true;
        player.voicePlayer.PlayOneShot(SFX);
    }

    public override void LogicUpdate()
    {
        //input.stopJump ||
        if (player.isFalling)
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
        base.OnExit();
    }
}