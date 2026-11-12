using System;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveArea : MonoBehaviour
{
    [SerializeField] UnityEvent _interactionCallback;
    private EntityInteraction _interaction;

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Interaction interaction))
        {
            interaction.Subscribe(_interactionCallback);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Interaction interaction))
        {
            interaction.UnSubscribe(_interactionCallback);
        }
    }
}
