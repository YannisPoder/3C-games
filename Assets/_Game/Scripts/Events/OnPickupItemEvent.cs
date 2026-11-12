using UnityEngine;

public class OnPickupItemEvent : IEvent
{
    public ItemData ItemData { get; private set; }
    public int Amount { get; private set; }

    public OnPickupItemEvent(ItemData itemData, int amount)
    {
        ItemData = itemData;
        Amount = amount;
    }
}
