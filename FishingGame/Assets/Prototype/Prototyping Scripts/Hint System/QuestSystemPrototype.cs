using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestSystemPrototype : MonoBehaviour
{
    public static QuestSystemPrototype instance;

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

    public TMP_Text CurrencyText;
    public GameObject CurrencyObject;

    public GameObject LocationTracker;
    public TMP_Text LocationTrackerTXT;

    [Header("Bools")]
    public bool QuestComplete;
    public bool QuestRecieved;
    public string debug;
    public bool MasterQuestSystem;
    public bool RefreshQuest;
    public bool SceneCheckWorld;
    public bool firstQuest;
    public bool SceneCheckShop;

    [Header("GameObjects")]
    public GameObject CurrentQuestSpot;
    public GameObject DND_UI;
    
    public Canvas DND_UICanvas;

    [Header("Sprites")]
    public Sprite HeadCustomerSprite;
    public Sprite TorsoCustomerSprite;
    public Sprite FaceCustomerSprite;

    public int RewardAmountTest;

    public int AmountOfQuestsCompleted;

    public Vector3 PlayerPosition;
    public GameObject Player;
    public GameObject EndScreen;

    //public bool questcomplete;

    // Update is called once per frame
    void Awake()
    {
        firstQuest = true;
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
            if (SceneCheckWorld == true)
            {
                SetQuestSpots();
                Player = GameObject.Find("--- PLAYER ---");
                Player.transform.position = PlayerPosition;
                DND_UI = GameObject.Find("DND_UI");
                DND_UICanvas = DND_UI.GetComponent<Canvas>();
                DND_UICanvas.enabled = false;
                SceneCheckShop = true;
                
               
                LocationTracker = GameObject.Find("LocationTracker");
                LocationTrackerTXT = LocationTracker.GetComponent<TMP_Text>();
                if (QuestComplete == false)
                {
                    LocationTrackerTXT.text = "Go To: " + CurrentQuest.Location.ToString();
                }
                else if (QuestComplete == true)
                {
                    LocationTrackerTXT.text = "Go To: The Shop!";
                }


                    SceneCheckWorld = false;
            }
        }

         else if (SceneManager.GetActiveScene().name == "TheShop")
         {
             if (SceneCheckShop == true)
             {
                 DND_UI = GameObject.Find("DND_UI");
                 DND_UICanvas = DND_UI.GetComponent<Canvas>();
                 DND_UICanvas.enabled = true;
                 DND_UI.SetActive(true);
                 SceneCheckWorld = true;
                 SceneCheckShop = false;
                //Debug.Log(CurrentQuest.RewardAmount);
                // Debug.Log(CurrencyText.text);
            }
         }
        
       // CurrencyObject = GameObject.Find("DND_UI/Currency");
        //CurrencyText = CurrencyObject.GetComponent<TMP_Text>();
        //CurrencyText.text = RewardAmountTest.ToString();
        if (AmountOfQuestsCompleted >= 5)
        {
            EndScreen.SetActive(true);
            
        }
    }

    public void GetQuest()
    {
        
        
        Debug.Log("finding");
       // LocationObject = GameObject.Find("DND_UI/Location");
       // LocationText = LocationObject.GetComponent<TMP_Text>();
       // QuestObject = GameObject.Find("DND_UI/QuestName");
       // QuestText = QuestObject.GetComponent<TMP_Text>();
       // RewardObject = GameObject.Find("DND_UI/RewardAmount");
       // RewardText = RewardObject.GetComponent<TMP_Text>();
        CustomerDialogueObject = GameObject.Find("DND_UI/Dialogue");
        CustomerDialogue = CustomerDialogueObject.GetComponent<TMP_Text>();

        
            AmountOfQuestsCompleted++;
            Quests = Resources.LoadAll<QuestScriptables>("Quests");
            
            CurrentQuest = Quests[Random.Range(0, Quests.Length)];
           // LocationText.text = CurrentQuest.Location.ToString();
           // QuestText.text = CurrentQuest.QuestName.ToString();
           // RewardText.text = CurrentQuest.RewardAmount.ToString();
            CustomerDialogue.text = CurrentQuest.CustomerText.ToString();
            QuestComplete = false;
            QuestRecieved = true;
            ShopManager.instance.RandomiseCustomer();
            MasterQuestSystem = true;
            RewardAmountTest += CurrentQuest.RewardAmount;

        return;
            

           /* if (firstQuest == false)
            {
                CurrencyObject = GameObject.Find("Currency");
                CurrencyText = CurrencyObject.GetComponent<TMP_Text>();
                CurrencyText.text = "Currency:  " + Mathf.RoundToInt(RewardAmountTest).ToString();
            }
            if (firstQuest == true && RewardAmountTest == 0) {
                CurrencyObject = GameObject.Find("Currency");
                CurrencyText = CurrencyObject.GetComponent<TMP_Text>();
                CurrencyText.text = "Currency: 0";

                }
            firstQuest = false;
           */
        
    }

    public void SetQuestSpots()
    {
        debug = CurrentQuest.Location.ToString();
        CurrentQuestSpot = GameObject.Find(CurrentQuest.Location.ToString());

    }
}
