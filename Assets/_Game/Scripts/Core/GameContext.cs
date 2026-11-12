using UnityEngine;

public class GameContext
{
    public EventBus EventBus { get; private set; }
    public GameContext(EventBus events)
    {
        EventBus = events;
    }
}
