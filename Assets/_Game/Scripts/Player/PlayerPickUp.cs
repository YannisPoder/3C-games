using UnityEngine;

public class PlayerPickUp : MonoBehaviour, IContextInitialise
{
    EventBus _eventBus;

    public void Initialise(EventBus events)
    {
        _eventBus = events;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickUpItem item))
        {
            _eventBus.Publish(new OnPickupItemEvent(item.Data, 1));
            Destroy(other.gameObject);
        }
    }
}
