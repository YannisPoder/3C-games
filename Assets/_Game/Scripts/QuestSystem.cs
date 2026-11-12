using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private RectTransform _questList;
    private List<QuestSlotUI> _questSlots = new();
    private List<ProgressionStepRuntime> _Steps = new();

    public void AddQuest(ProgressionStep step, ProgressionStepRuntime stepR)
    {
        GameObject newPrefab = Instantiate(_prefab, _questList);
        QuestSlotUI newQuestSlotUI = newPrefab.GetComponent<QuestSlotUI>();
        newQuestSlotUI.Initialize(step.ID, step.Title, stepR);
        _questSlots.Add(newQuestSlotUI);
    }
    public void RemoveQuest(ProgressionStep step)
    {
        foreach (QuestSlotUI questSlot in _questSlots)
        {
            if (questSlot.ID == step.ID)
            {
                _questSlots.Remove(questSlot);
                Destroy(questSlot.gameObject);
                return;
            }
        }
    }
    void UpdateQuests()
    {
        foreach(QuestSlotUI questSlot in _questSlots)
        {
            questSlot.UpdateQuest();
        }
    }
    private void Update()
    {
        UpdateQuests();
    }
}
