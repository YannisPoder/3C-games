using UnityEngine;

public class PickUpItemConditionRuntime : ConditionRuntime
{
    private PickUpItemCondition _definition;
    private float _currentAmount;

    public PickUpItemConditionRuntime(PickUpItemCondition definition, EventBus eventBus) : base(eventBus)
    {
        _definition = definition;
        ProgressionText = _definition.ItemData.name + " : " + _currentAmount + "/" + _definition.TargetAmount;
        _eventBus.Subscribe<OnPickupItemEvent>(OnPickUp);
    }
    private void OnPickUp(OnPickupItemEvent @event)
    {
        if (@event.ItemData != _definition.ItemData)
            return;

        _currentAmount += @event.Amount;

        if (_currentAmount >= _definition.TargetAmount)
        {
            IsCompleted = true;
        }

        UpdateText();
    }
    public override void Dispose()
    {
        _eventBus.UnSubscribe<OnPickupItemEvent>(OnPickUp);
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
