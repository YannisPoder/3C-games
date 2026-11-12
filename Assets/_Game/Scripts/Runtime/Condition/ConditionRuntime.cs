using UnityEngine;

public abstract class ConditionRuntime
{
    protected EventBus _eventBus;
    public string ProgressionText { get; protected set; }
    public bool IsCompleted { get; protected set; }

    protected ConditionRuntime(EventBus eventBus)
    {
        _eventBus = eventBus;
    }
    public abstract void Dispose();
    protected abstract void UpdateText();
}
