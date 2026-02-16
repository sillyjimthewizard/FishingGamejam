using TMPro;
using UnityEngine;

public class QuestSystemPrototype : MonoBehaviour
{
    [Header("Scriptable Objects")]
    public QuestScriptables[] Quests;
    public QuestScriptables CurrentQuest;

    [Header("Text References")]
    public TMP_Text LocationText;
    public TMP_Text QuestText;
    public TMP_Text RewardText;
    public TMP_Text CustomerDialogue;

    public static QuestSystemPrototype instance;

    //public bool questcomplete;

    // Update is called once per frame
    void Awake()
    {
        instance = this;
        
    }

    public void GetQuest()
    {
        if (ShopManager.instance.TempPlayerStats.QuestComplete == true)
        {
            CurrentQuest = Quests[Random.Range(0, Quests.Length)];
            LocationText.text = CurrentQuest.Location.ToString();
            QuestText.text = CurrentQuest.QuestName.ToString();
            RewardText.text = CurrentQuest.RewardAmount.ToString();
            CustomerDialogue.text = CurrentQuest.CustomerText.ToString();

            ShopManager.instance.RandomiseCustomer();
        }
    }
}
