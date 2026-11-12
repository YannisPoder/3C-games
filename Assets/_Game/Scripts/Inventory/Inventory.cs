using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IContextInitialise
{
    private Dictionary<ItemData, int> _inventoryItems;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Transform _inventorySlots;
    List<ItemSlot> _itemSlots = new();
    //Size inventory

    private EventBus _eventBus;
    private void Awake()
    {
        _inventoryItems = new();
    }
    private void Start()
    {
        _inventoryPanel.SetActive(false);
        InitItemSlots();
    }
    void InitItemSlots()
    {
        for (int i = 0; i < _inventorySlots.childCount - 1; i++)
        {
            _itemSlots.Add(_inventorySlots.GetChild(i).GetComponent<ItemSlot>());
        }
    }
    public void AddItem(OnPickupItemEvent @event)
    {
        bool isItemExist = false;
        int index = 0;

        foreach (ItemSlot slot in _itemSlots)
        {
            if (slot.Data == null)
            {
                if (!isItemExist)
                {
                    slot.Data = @event.ItemData;
                }
            }

            if(slot.Data == @event.ItemData)
            {
                slot.SetAmount(@event.Amount);
                UpdateInventory(index);
                isItemExist = true;
                return;
            }

            index++;
        }
    }
    public bool RemoveItem(ItemData item, int amount)
    {
        if (_inventoryItems.TryGetValue(item, out int currentAmount))
        {
            if(currentAmount >= amount)
            {
                _inventoryItems[item] -= amount;
                return true;
            }
        }

        return false;
    }

    void UpdateInventory(int index)
    {
        _itemSlots[index].transform.GetChild(0).GetComponent<Image>().sprite = _itemSlots[index].Data.Sprite;
        _itemSlots[index].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _itemSlots[index].Amount.ToString();
    }

    public void Initialise(EventBus events)
    {
        _eventBus = events;
        _eventBus.Subscribe<OnPickupItemEvent>(AddItem);
    }
}
