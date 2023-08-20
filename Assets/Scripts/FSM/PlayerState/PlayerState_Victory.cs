using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerState/Victory"), fileName = ("PlayerState_Victory"))]
public class PlayerState_Victory : PlayerState
{
    public override void OnEnter()
    {
        base.OnEnter();
        input.DisableGameplayInput();
    }
}
