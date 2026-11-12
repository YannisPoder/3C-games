using System.Collections.Generic;
using UnityEngine;

public class ProgressionStepRuntime
{
    private string _progressionText;
    public string ProgressionText 
    {
        get
        {
            _progressionText = string.Empty;
            foreach(ConditionRuntime condition in _conditions)
            {
                _progressionText += condition.ProgressionText + "\n";
            }
            return _progressionText;
        }
    }
    private List<ConditionRuntime> _conditions;
    private List<Reward> _rewards;
    public bool IsCompleted
    {
        get
        {
            foreach (ConditionRuntime condition in _conditions)
            {
                if (!condition.IsCompleted)
                    return false;
            }
            Debug.Log("All Condition completed");
            return true;
        }
    }
    public ProgressionStepRuntime(List<ConditionRuntime> conditions, List<Reward> rewards)
    {
        _conditions = conditions;
        _rewards = rewards;
    }
    public void Dispose()
    {
        foreach (ConditionRuntime condition in _conditions)
        {
            condition.Dispose();
        }
        foreach (Reward reward in _rewards)
        {
            reward.Give();
        }
    }
}
