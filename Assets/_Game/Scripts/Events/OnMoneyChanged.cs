using UnityEngine;

public class OnMoneyChanged : IEvent
{
    public int Amount {  get; private set; }

    public OnMoneyChanged(int amount)
    {
        Amount = amount;
    }
}
