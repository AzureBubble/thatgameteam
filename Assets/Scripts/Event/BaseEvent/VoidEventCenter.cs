using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Event/VoidEventCenter"), fileName = ("VoidEventCenter"))]
public class VoidEventCenter : ScriptableObject
{
    private event Action OnEventRaised;

    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }

    public void AddListener(Action action)
    {
        OnEventRaised += action;
    }

    public void RemoveListener(Action action)
    {
        OnEventRaised -= action;
    }
}
