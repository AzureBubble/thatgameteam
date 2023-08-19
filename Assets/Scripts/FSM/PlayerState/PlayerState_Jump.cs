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