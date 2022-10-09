using System;
using UnityEngine;

/// <summary>
/// Game events can be shared between multiples scenes
/// and raise by multiples instances. It creates an abstraction layer
/// between listeners and callers.
/// </summary>
/// <typeparam name="T">Send value type send by the caller to each listener</typeparam>
public abstract class GameEvent<T> : ScriptableObject
{
    private Action<T> _listeners;

    public void Raise(T value) => _listeners?.Invoke(value);

    public void RegisterListener(Action<T> listener)
    {
        if (listener != null)
        {
            _listeners += listener;
        }
    }
    
    public void UnregisterListener(Action<T> listener)
    {
        if (listener != null)
        {
            _listeners -= listener;
        }
    }
}
