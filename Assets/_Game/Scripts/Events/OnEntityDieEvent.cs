using Unity.VisualScripting;
using UnityEngine;

public class OnEntityDieEvent : IEvent
{
    public EntityData EntityData { get; private set; }

    public OnEntityDieEvent(EntityData entityData)
    { 
        EntityData = entityData; 
    }
}
