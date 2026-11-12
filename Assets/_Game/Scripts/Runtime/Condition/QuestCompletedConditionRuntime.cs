using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class QuestCompletedConditionRuntime : ConditionRuntime
{
    private QuestCompletedCondition _definition;
    public QuestCompletedConditionRuntime(QuestCompletedCondition definition, EventBus eventBus) : base(eventBus)
    {
        _definition = definition;
        ProgressionText = (_definition.QuestId).ToString() + " in progress";
        _eventBus.Subscribe<OnQuestCompletedEvent>(Progress);
    }
    void Progress(OnQuestCompletedEvent @event)
    {
        if (@event.Step.ID == _definition.QuestId)
        {
            IsCompleted = true;
        }

        UpdateText();
    }
    public override void Dispose()
    {
        _eventBus.UnSubscribe<OnQuestCompletedEvent>(Progress);
    }
    protected override void UpdateText()
    {
        if (IsCompleted)
        {
            ProgressionText = "Condition completed";
        }
    }
}
