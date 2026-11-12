using UnityEngine;

public class CraftConditionRuntime : ConditionRuntime
{
    private CraftCondition _definition;
    private float _currentAmount;

    public CraftConditionRuntime(CraftCondition definition, EventBus eventBus) : base(eventBus)
    {
        _definition = definition;
        ProgressionText = "Craft " + _definition.TargetAmount + " " + _definition.ItemData.name;
        _eventBus.Subscribe<OnCraftEvent>(OnPickUp);
    }
    private void OnPickUp(OnCraftEvent @event)
    {
        if (@event.ItemData != _definition.ItemData)
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
        _eventBus.UnSubscribe<OnCraftEvent>(OnPickUp);
    }

    protected override void UpdateText()
    {
        if (IsCompleted)
        {
            ProgressionText = "Condition completed";
        }
    }
}
