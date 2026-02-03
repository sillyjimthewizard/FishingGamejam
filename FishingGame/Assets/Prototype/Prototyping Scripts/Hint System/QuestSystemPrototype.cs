using NUnit.Framework.Interfaces;
using TMPro;
using UnityEngine;

public class QuestSystemPrototype : MonoBehaviour
{
    public QuestScriptables[] Quests;
    public QuestScriptables CurrentQuest;

    public TMP_Text LocationText;
    public TMP_Text QuestText;
    public TMP_Text RewardText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            CurrentQuest = Quests[Random.Range(0, Quests.Length)];

            LocationText.text = CurrentQuest.Location.ToString();
            QuestText.text = CurrentQuest.QuestName.ToString();
            RewardText.text = CurrentQuest.RewardAmount.ToString();
        }
    }
}
