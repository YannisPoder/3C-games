using UnityEngine;

[CreateAssetMenu(fileName = "TryPickUpItemCondition", menuName = "Scriptable Objects/Conditions/TryPickUpItemCondition")]
public class PickUpItemCondition : Condition
{
    public ItemData ItemData => _itemData;
    [SerializeField] private ItemData _itemData;
    public float TargetAmount => _targetAmount;
    [SerializeField] private float _targetAmount;
    public override ConditionRuntime CreateRunTime(EventBus eventBus)
    {
        return new PickUpItemConditionRuntime(this, eventBus);
    }
}
