using UnityEngine;

public abstract class Reward : ScriptableObject
{
    protected EventBus _eventBus;

    public void Initialize(EventBus eventBus)
    {
        _eventBus = eventBus;
    }
    public abstract void Give();
}
