using System;
using TMPro;
using UnityEngine;

public class QuestSlotUI : MonoBehaviour
{
    public string ID => _id.text;
    [SerializeField] private TextMeshProUGUI _id;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _progression;

    private ProgressionStepRuntime _stepRuntime;
    public void Initialize(string id, string title, ProgressionStepRuntime stepRuntime)
    {
        _id.text = id;
        _title.text = title;
        _stepRuntime = stepRuntime;
        _progression.SetText(_stepRuntime.ProgressionText);
    }
    public void UpdateQuest()
    {
        _progression.SetText(_stepRuntime.ProgressionText);
    }
}
