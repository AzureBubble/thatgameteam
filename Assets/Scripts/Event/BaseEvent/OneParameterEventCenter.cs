using System;
using UnityEngine;

//[CreateAssetMenu(menuName = ("Event/OneParamaterEventCenter"), fileName = ("OneParamaterEventCenter"))]
public class OneParamaterEventCenter<T> : ScriptableObject
{
    private event Action<T> OnEventRaised;

    public void RaisedEvent(T obj)
    {
        OnEventRaised?.Invoke(obj);
    }

    public void AddListener(Action<T> action)
    {
        OnEventRaised += action;
    }

    public void RemoveListener(Action<T> action)
    {
        OnEventRaised -= action;
    }
}