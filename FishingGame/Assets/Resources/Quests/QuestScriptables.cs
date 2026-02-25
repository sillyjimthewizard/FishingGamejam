using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestName", menuName = "QuestData")]

public class QuestScriptables : ScriptableObject
{

    [Header("Start The Name With A Capital, pls name the asset the same name")]
    public string QuestName;

    [Header("Num Between 1-1000")]
    public int RewardAmount;

    [Header("Name A Already Existing object (look at trello) Start it with a capital")]
    public string ObjectWanted;

    [Header("Start The Name With A Capital")]
    public string Location;

    [Header("Put the quest dialogue here")]
    public string CustomerText;

    [Header("Put the Sprite here")]
    public Sprite QuestObjectSprite;

}
