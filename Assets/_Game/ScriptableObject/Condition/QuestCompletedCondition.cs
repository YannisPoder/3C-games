using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName = "QuestCompletedCondition", menuName = "Scriptable Objects/Conditions/QuestCompletedCondition")]
public class QuestCompletedCondition : Condition
{
    public string QuestId => _questId;
    [SerializeField] private string _questId;
    public override ConditionRuntime CreateRunTime(EventBus eventBus)
    {
        return new QuestCompletedConditionRuntime(this, eventBus);
    }
}
