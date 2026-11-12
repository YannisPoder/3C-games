using UnityEngine;

public class OnQuestCompletedEvent: IEvent
{
    public ProgressionStep Step { get; }
    public OnQuestCompletedEvent(ProgressionStep step)
    {
        Step = step;
    }
}
