using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EntityInteraction))]
public class PNJProgression : MonoBehaviour, IContextInitialise
{
    EventBus _eventBus;
    [SerializeField] private List<ProgressionStep> _quests;
    private ProgressionStepRuntime _currentStep;
    [SerializeField] private QuestSystem _questSystem;
    private int index = 0;

    //hmm
    EntityInteraction _entityInteraction;
    private void Start()
    {
        _entityInteraction = GetComponent<EntityInteraction>();
    }
    public void Initialise(EventBus events)
    {
        _eventBus = events;
    }
    void NextStep()
    {
        DisposeQuest();

        if (index >= _quests.Count - 1)
        {
            index = -1;
            return;
        }

        index++;

        InitializeQuest();
    }

    void InitializeQuest()
    {
        _currentStep = _quests[index].CreateRuntime(_eventBus);
        _questSystem.AddQuest(_quests[index], _currentStep);
    }
    void DisposeQuest()
    {
        _currentStep.Dispose();

        _eventBus.Publish(new OnQuestCompletedEvent(_quests[index]));

        _questSystem.RemoveQuest(_quests[index]);
    }

    public void InitializePNJ()
    {
        if (index == -1)
            return;
        if (_entityInteraction.NeverInteract)
        {
            InitializeQuest();
        }

        if (_currentStep.IsCompleted)
        {
            NextStep();
        }
    }
}
