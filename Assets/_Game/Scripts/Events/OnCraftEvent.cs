using Unity.VisualScripting;
using UnityEngine;

public class OnCraftEvent : IEvent
{
    public ItemData ItemData { get; private set; }
    public int Amount { get; private set; }

    public OnCraftEvent(ItemData entityData, int amount)
    { 
        ItemData = entityData;
        Amount = amount;
    }
}
