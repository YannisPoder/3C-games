using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerInputController _pIC;
    [SerializeField] private GameObject _inventoryPanel;

    private void Awake()
    {
        _pIC.OnInventory += UseInventory;
    }

    void UseInventory(InputAction.CallbackContext context)
    {
        _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
    }
}
