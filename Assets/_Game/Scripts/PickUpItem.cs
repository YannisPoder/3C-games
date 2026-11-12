using UnityEngine;

public class PickUpItem: MonoBehaviour
{
    [SerializeField] private ItemData _itemData;

    public ItemData Data { get => _itemData; }

}
