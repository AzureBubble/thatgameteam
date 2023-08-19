using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    private IState currentState;
    protected Dictionary<System.Type, IState> stateDict;

    private void Update()
    {
        currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        currentState.PhysicsUpdate();
    }

    #region ÇÐ»»¡¢Æô¶¯×´Ì¬

    public void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.OnEnter();
    }

    public void SwitchState(IState newState)
    {
        currentState.OnExit();
        SwitchOn(newState);
    }

    public void SwitchState(System.Type newState)
    {
        currentState.OnExit();
        SwitchState(stateDict[newState]);
    }

    #endregion
}
