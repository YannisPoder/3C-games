using UnityEngine;

[CreateAssetMenu(fileName = "CraftCondition", menuName = "Scriptable Objects/Conditions/CraftCondition  ")]
public class CraftCondition : Condition
{
    public ItemData ItemData => _itemData;
    [SerializeField] private ItemData _itemData;
    public float TargetAmount => _targetAmount;
    [SerializeField] private float _targetAmount;
    public override ConditionRuntime CreateRunTime(EventBus eventBus)
    {
        return new CraftConditionRuntime(this, eventBus);
    }
}
