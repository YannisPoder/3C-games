using UnityEngine;

public class KillEnemyConditionRuntime : ConditionRuntime
{
    private KillEnemyCondition _definition;
    private float _currentAmount;

    public KillEnemyConditionRuntime(KillEnemyCondition definition, EventBus eventBus) : base(eventBus)
    {
        _definition = definition;
        ProgressionText = _definition.ItemData.name + " : " + _currentAmount + "/" + _definition.TargetAmount;
        _eventBus.Subscribe<OnEntityDieEvent>(OnPickUp);
    }
    private void OnPickUp(OnEntityDieEvent @event)
    {
        if (@event.EntityData != _definition.ItemData)
            return;

        _currentAmount++;

        if (_currentAmount >= _definition.TargetAmount)
        {
            IsCompleted = true;
        }

        UpdateText();
    }
    public override void Dispose()
    {
        _eventBus.UnSubscribe<OnEntityDieEvent>(OnPickUp);
    }

    protected override void UpdateText()
    {
        if (IsCompleted)
        {
            ProgressionText = "Condition completed";
        }
        else
        {
            ProgressionText = _definition.ItemData.name + " : " + _currentAmount + "/" + _definition.TargetAmount;
        }
    }
}
