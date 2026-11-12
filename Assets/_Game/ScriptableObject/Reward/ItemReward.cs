using UnityEditor.PackageManager;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemReward", menuName = "Scriptable Objects/Rewards/ItemReward")]
public class ItemReward : Reward
{
    public int Amount => _amount;
    [SerializeField] private int _amount;

    public ItemData Item =>_item;
    [SerializeField] private ItemData _item;
    public override void Give()
    {
        _eventBus.Publish(new OnPickupItemEvent(_item, _amount));
    }
}
