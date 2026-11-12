using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [Header("Dependances")]
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _interactInput;
    [SerializeField] InputActionReference _inventoryInput;
    [SerializeField] InputActionReference _meleeInput;
    [SerializeField] InputActionReference _mouseMove;
    [SerializeField] InputActionReference _gamepadRotate;

    public event Action<InputAction.CallbackContext> OnMove;
    public event Action<InputAction.CallbackContext> OnMoveStop;
    public event Action<InputAction.CallbackContext> OnInteract;
    public event Action<InputAction.CallbackContext> OnInventory;
    public event Action<InputAction.CallbackContext> OnMelee;
    public event Action<InputAction.CallbackContext> OnMouseMove;

    void Start()
    {
        _moveInput.action.performed += OnMove;
        _moveInput.action.canceled += OnMoveStop;
        _interactInput.action.started += OnInteract;
        _inventoryInput.action.started += OnInventory;
        _meleeInput.action.started += OnMelee;
        _mouseMove.action.performed += OnMouseMove;
        _gamepadRotate.action.performed += OnMouseMove;
    }

    void OnDestroy()
    {
        _moveInput.action.performed -= OnMove;
        _moveInput.action.canceled -= OnMoveStop;
        _interactInput.action.started -= OnInteract;
        _inventoryInput.action.started -= OnInventory;
        _meleeInput.action.started -= OnMelee;
        _mouseMove.action.performed -= OnMouseMove;
        _gamepadRotate.action.performed-= OnMouseMove;
    }

}