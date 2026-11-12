using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    UnityEvent _interactionCallback = null;
    [SerializeField] PlayerInputController _pIC;

    private void Awake()
    {
        _pIC.OnInteract += TryInteract;
    }
    public void Subscribe(UnityEvent interactionCallback)
    {
        _interactionCallback = interactionCallback;
    }
    public void UnSubscribe(UnityEvent interactionCallback)
    {
        if(_interactionCallback == interactionCallback)
        {
            _interactionCallback = null;
        }
    }
    void TryInteract(InputAction.CallbackContext context)
    {
        if (_interactionCallback == null)
            return;
        _interactionCallback.Invoke();
    }
}
