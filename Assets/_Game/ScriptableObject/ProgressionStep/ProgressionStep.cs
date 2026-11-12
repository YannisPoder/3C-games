using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ProgressionStep", menuName = "Scriptable Objects/ProgressionStep")]
public class ProgressionStep : ScriptableObject
{
    public string ID => _id;
    [SerializeField] private string _id;
    public string Title => _title;
    [SerializeField] private string _title;
    public List<Condition> DefConditions => _defConditions;
    [SerializeField] private List<Condition> _defConditions;
    public List<Reward> DefRewards => _defRewards;
    [SerializeField] private List<Reward> _defRewards;

    public ProgressionStepRuntime CreateRuntime(EventBus eventBus)
    {
        Debug.Log("Initialize Step : " + Title);

        List<ConditionRuntime> conditions = new();
        List<Reward> rewards = new();

        foreach (Condition condition in DefConditions)
        {
            conditions.Add(condition.CreateRunTime(eventBus));
        }
        foreach (Reward reward in DefRewards)
        {
            reward.Initialize(eventBus);
        }

        return new ProgressionStepRuntime(conditions, DefRewards);
    }
}
