using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{
    //transformer en ScriptableObject
    Dictionary<Type, List<Delegate>> events = new();
    
    public void Subscribe<TEvent>(Action<TEvent> @event) where TEvent : IEvent
    {
        Type eventType = typeof(TEvent);
        if (!events.TryGetValue(eventType, out List<Delegate> callbacks))
        {

            callbacks = new List<Delegate>();
            callbacks.Add(@event);
            events.Add(eventType, callbacks);

        }
        else if (!events[eventType].Contains(@event))
        {
            events[eventType].Add(@event);
        }
    }
    public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        if (events.ContainsKey(typeof(TEvent)))
        {
            foreach (Delegate _delegate in events[typeof(TEvent)])
            {
                ((Action<TEvent>)_delegate).Invoke(@event);
            }
        }
    }
    public void UnSubscribe<TEvent>(Action<TEvent> callback) where TEvent : IEvent
    {
        Type eventType = typeof(TEvent);

        if (events[eventType].Contains(callback))
        {
            events[eventType].Remove(callback);
        }
    }
}
