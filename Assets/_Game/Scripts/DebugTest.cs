using UnityEngine;

public class DebugTest : MonoBehaviour, IContextInitialise
{
    EventBus _events;
    public void Initialise(EventBus events)
    {
        _events = events;
        _events.Subscribe<OnEntityDieEvent>(Test);
    }

    void Test(OnEntityDieEvent e)
    {
        Debug.Log("Dead");
    }
}
