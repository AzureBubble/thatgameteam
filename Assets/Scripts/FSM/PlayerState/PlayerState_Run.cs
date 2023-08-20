using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/Run"), fileName = ("PlayerState_Run"))]
public class PlayerState_Run : PlayerState
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private AudioClip SFX;

    public override void OnEnter()
    {
        base.OnEnter();
        //player.voicePlayer.PlayOneShot(SFX);
        player.voicePlayer.loop = true;
    }

    public override void LogicUpdate()
    {
        if (!player.voicePlayer.isPlaying)
        {
            player.voicePlayer.PlayOneShot(SFX);
        }
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
        player.voicePlayer.Stop();
        player.voicePlayer.loop = false;
    }
}