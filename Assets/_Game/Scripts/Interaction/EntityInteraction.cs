using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EntityInteraction : MonoBehaviour
{
    private bool _neverInteract = true;
    public bool NeverInteract { get => _neverInteract; }

    public UnityEvent _interact;

    public void Interact()
    {
        _interact.Invoke();

        if (_neverInteract)
        {
            _neverInteract = false;
        }

    }
}
