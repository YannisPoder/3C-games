using UnityEditor.PackageManager;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyReward", menuName = "Scriptable Objects/Rewards/MoneyReward")]
public class MoneyReward : Reward
{
    [SerializeField] private int _amount;
    public override void Give()
    {
        _eventBus.Publish(new OnMoneyChanged(_amount));
    }
}
