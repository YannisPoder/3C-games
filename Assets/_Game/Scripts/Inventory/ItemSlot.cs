using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private ItemData _data = null;
    private int _amount = 0;
    public int Amount { get => _amount; }
    public ItemData Data { get => _data; set => _data = value; }

    public void SetAmount(int amount)
    {
        _amount += amount;
    }
}
