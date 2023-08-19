using System;
using UnityEngine;


public class TwoParameterEventCenter<T1, T2> : ScriptableObject
{
    private event Action<T1, T2> OnEventRaised;

    public void RaisedEvent(T1 obj1, T2 obj2)
    {
        OnEventRaised?.Invoke(obj1, obj2);
    }

    public void AddListener(Action<T1, T2> action)
    {
        OnEventRaised += action;
    }

    public void RemoveListener(Action<T1, T2> action)
    {
        OnEventRaised -= action;
    }
}