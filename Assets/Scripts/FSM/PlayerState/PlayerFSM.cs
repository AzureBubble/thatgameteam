using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : FSM
{
    [SerializeField] private PlayerState[] states;
    private Animator animator;
    private PlayerController player;
    private PlayerInput input;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GetComponent<PlayerController>();
        input = GetComponent<PlayerInput>();
        stateDict = new Dictionary<System.Type, IState>(states.Length);

        foreach (PlayerState state in states)
        {
            state.Init(player, input, animator, this);
            stateDict.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        SwitchOn(stateDict[typeof(PlayerState_Idle)]);
    }
}