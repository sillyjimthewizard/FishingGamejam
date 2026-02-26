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
    public TMP_Text LocationText;
    public GameObject LocationObject;
    public TMP_Text QuestText;
    public GameObject QuestObject;
    public TMP_Text RewardText;
    public GameObject RewardObject;
    public TMP_Text CustomerDialogue;
    public GameObject CustomerDialogueObject;

    public static QuestSystemPrototype instance;

    public bool QuestComplete;
    public bool QuestRecieved;
    public string debug;
    public bool MasterQuestSystem;
    public bool RefreshQuest;
    public bool SceneCheck;

    [Header("GameObjects")]
    public GameObject CurrentQuestSpot;
    public GameObject DND_UI;
    public Canvas DND_UICanvas;

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
           
        }
        
       
    }

    public void Update()
    {

        //LocationObject = GameObject.Find("Location");
        //LocationText = LocationObject.GetComponent<TextMeshPro>();
        //QuestObject = GameObject.Find("UI/QuestName");
        //QuestText = QuestObject.GetComponent<TextMeshPro>();
        //RewardObject = GameObject.Find("UI/RewardAmount");
        //RewardText = RewardObject.GetComponent<TextMeshPro>();
        //CustomerDialogueObject = GameObject.Find("UI/Dialogue");
        //CustomerDialogue = CustomerDialogueObject.GetComponent<TextMeshPro>();


        if (SceneManager.GetActiveScene().name == "MainWorld")
        {
            if (SceneCheck == true)
            {
                SetQuestSpots();
                DND_UI = GameObject.Find("DND_UI");
                DND_UICanvas = DND_UI.GetComponent<Canvas>();
                DND_UICanvas.enabled = false;
                SceneCheck = false;
            }
        }

        else if (SceneManager.GetActiveScene().name == "TheShop")
        {
            if (SceneCheck == false)
            {
                DND_UI = GameObject.Find("DND_UI");
                DND_UICanvas = DND_UI.GetComponent<Canvas>();
                DND_UICanvas.enabled = true;
                DND_UI.SetActive(true);
                SceneCheck = true;
            }
        }
    }

    public void GetQuest()
    {
        if (QuestComplete == true)
        {

            LocationObject = GameObject.Find("Location");
            LocationText = LocationObject.GetComponent<TMP_Text>();
            QuestObject = GameObject.Find("UI/QuestName");
            QuestText = QuestObject.GetComponent<TMP_Text>();
            RewardObject = GameObject.Find("UI/RewardAmount");
            RewardText = RewardObject.GetComponent<TMP_Text>();
            CustomerDialogueObject = GameObject.Find("Dialogue");
            CustomerDialogue = CustomerDialogueObject.GetComponent<TMP_Text>();


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

   

    public void TrashQuestObject()
    {
        QuestComplete = true;

    }

    public void SetQuestSpots()
    {
        debug = CurrentQuest.Location.ToString();
        CurrentQuestSpot = GameObject.Find(CurrentQuest.Location.ToString());

    }




}
