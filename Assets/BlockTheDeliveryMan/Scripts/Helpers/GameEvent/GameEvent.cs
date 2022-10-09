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

    public void Raise(T value)
    {
        if (_listeners == null) return;
        
        foreach (var current in _listeners.GetInvocationList())
        {
            if (current.Target.Equals(null))
            {
                Debug.LogError($"Memory Leak - An object with {current.Method} as a listener has been destroyed, but he doesn't unregister from {name}.");
                continue;
            }

            current.DynamicInvoke(value);
        }
    }

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
