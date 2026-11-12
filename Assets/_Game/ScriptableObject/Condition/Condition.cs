using UnityEngine;

public abstract class Condition : ScriptableObject
{
    public abstract ConditionRuntime CreateRunTime(EventBus eventBus);
}
