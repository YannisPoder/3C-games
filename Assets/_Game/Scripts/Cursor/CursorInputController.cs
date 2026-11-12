using UnityEngine;
using UnityEngine.InputSystem;

public class CursorInputController : MonoBehaviour
{
    [SerializeField] InputActionReference _camMove;
    [SerializeField] InputActionReference _mouseMove;
    [SerializeField] InputActionReference _center;

    public event System.Action<InputAction.CallbackContext> OnMoveCam;
    public event System.Action<InputAction.CallbackContext> OnMouseStop;
    public event System.Action<InputAction.CallbackContext> OnCenter;

    void Start()
    {        
        _camMove.action.performed += OnMoveCam;
        _mouseMove.action.performed += OnMoveCam;
        _camMove.action.canceled += OnMouseStop;
        _mouseMove.action.canceled += OnMouseStop;
        _center.action.started += OnCenter;
    }

    void OnDestroy()
    {
        _camMove.action.performed -= OnMoveCam;
        _mouseMove.action.performed -= OnMoveCam;
        _camMove.action.canceled -= OnMouseStop;
        _mouseMove.action.canceled -= OnMouseStop;
        _center.action.started -= OnCenter;
    }
}
