using System.Collections;
using System.Collections.Generic;
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
        if (input.stopJump||player.isFalling)
        {
            fsm.SwitchState((typeof(PlayerState_Fall)));
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
