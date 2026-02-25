using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestSystemPrototype : MonoBehaviour
{
    [Header("Scriptable Objects")]
    public QuestScriptables[] Quests;
    public QuestScriptables CurrentQuest;

    [Header("Text References")]
    public TextMeshPro LocationText;
    public GameObject LocationObject;
    public TextMeshPro QuestText;
    public GameObject QuestObject;
    public TextMeshPro RewardText;
    public GameObject RewardObject;
    public TextMeshPro CustomerDialogue;
    public GameObject CustomerDialogueObject;

    public static QuestSystemPrototype instance;

    public bool QuestComplete;
    public bool QuestRecieved;
    public string debug;
    public bool MasterQuestSystem;
    public bool RefreshQuest;

    [Header("GameObjects")]
    public GameObject CurrentQuestSpot;

    [Header("Sprites")]
    public Sprite HeadCustomerSprite;
    public Sprite TorsoCustomerSprite;
    public Sprite FaceCustomerSprite;

    //public bool questcomplete;

    // Update is called once per frame
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("QuestSystem");

        if (objs.Length > 1 && MasterQuestSystem == false)
        {
            Destroy(this.gameObject);
            RefreshTimer();
        }
        else
        {
            StartCoroutine(RefreshTimer());

        }
        ShowQuest();
    }

   

    public void Update()
    {

        LocationObject = GameObject.Find("Location");
        LocationText = LocationObject.GetComponent<TextMeshPro>();
        QuestObject = GameObject.Find("UI/QuestName");
        QuestText = QuestObject.GetComponent<TextMeshPro>();
        RewardObject = GameObject.Find("UI/RewardAmount");
        RewardText = RewardObject.GetComponent<TextMeshPro>();
        CustomerDialogueObject = GameObject.Find("UI/Dialogue");
        CustomerDialogue = CustomerDialogueObject.GetComponent<TextMeshPro>();


        if (SceneManager.GetActiveScene().name == "MainWorld")
        {
            SetQuestSpots();
        }

        if (SceneManager.GetActiveScene().name == "TheShop")
        {

           

            ShowQuest();
            

        }
    }

    public void GetQuest()
    {
        if (QuestComplete == true)
        {
            Quests = Resources.LoadAll<QuestScriptables>("Quests");
            CurrentQuest = Quests[Random.Range(0, Quests.Length)];
            LocationText.text = CurrentQuest.Location.ToString();
            QuestText.text = CurrentQuest.QuestName.ToString();
            RewardText.text = CurrentQuest.RewardAmount.ToString();
            CustomerDialogue.text = CurrentQuest.CustomerText.ToString();
            QuestComplete = false;
            QuestRecieved = true;
            ShopManager.instance.RandomiseCustomer();
            MasterQuestSystem = true;

        }
    }

    public void ShowQuest()
    {
        Debug.Log("ShowQuestDebug");
        LocationObject = GameObject.Find("Location");
        LocationText = LocationObject.GetComponent<TextMeshPro>();
        QuestObject = GameObject.Find("UI/QuestName");
        QuestText = QuestObject.GetComponent<TextMeshPro>();
        RewardObject = GameObject.Find("UI/RewardAmount");
        RewardText = RewardObject.GetComponent<TextMeshPro>();
        CustomerDialogueObject = GameObject.Find("UI/Dialogue");
        CustomerDialogue = CustomerDialogueObject.GetComponent<TextMeshPro>();

        LocationText.text = CurrentQuest.Location.ToString();
        QuestText.text = CurrentQuest.QuestName.ToString();
        RewardText.text = CurrentQuest.RewardAmount.ToString();
        CustomerDialogue.text = CurrentQuest.CustomerText.ToString();

        ShopManager.instance.HeadRenderer.sprite = HeadCustomerSprite;
        ShopManager.instance.FaceRenderer.sprite = FaceCustomerSprite;
        ShopManager.instance.BodyRenderer.sprite = TorsoCustomerSprite;


        RefreshQuest = false;
    }

    public void TrashQuestObject()
    {
        QuestComplete = true;

    }

    public void SetQuestSpots()
    {
        debug = CurrentQuest.Location.ToString();
        CurrentQuestSpot = GameObject.Find(CurrentQuest.Location.ToString());

    }

    public IEnumerator RefreshTimer()
    {

        yield return new WaitForSeconds(0.1f);
        RefreshQuest = true;
        ShowQuest();
        Debug.Log("refresh");
        yield return new WaitForSeconds(1f);
        RefreshQuest = true;
        ShowQuest();
        Debug.Log("refresh2");

    }


}
