using UnityEngine;

public class Wallet : MonoBehaviour, IContextInitialise
{
    EventBus _eventBus;
    public int Balance { get; private set; }

    private void Start()
    {
        _eventBus.Subscribe<OnMoneyChanged>(Add);
    }
    void Add(OnMoneyChanged @event)
    {
        Balance += @event.Amount;
    }

    public void Initialise(EventBus events)
    {
        _eventBus = events;
    }
}
