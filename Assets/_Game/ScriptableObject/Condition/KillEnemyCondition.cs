using UnityEngine;

[CreateAssetMenu(fileName = "KillEnemyCondition", menuName = "Scriptable Objects/Conditions/KillEnemyCondition")]
public class KillEnemyCondition : Condition
{
    public EntityData ItemData => _itemData;
    [SerializeField] private EntityData _itemData;
    public float TargetAmount => _targetAmount;
    [SerializeField] private float _targetAmount;
    public override ConditionRuntime CreateRunTime(EventBus eventBus)
    {
        return new KillEnemyConditionRuntime(this, eventBus);
    }
}
