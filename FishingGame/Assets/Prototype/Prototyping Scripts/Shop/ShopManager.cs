
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public Sprite[] TorsoImages;
    public Sprite[] HeadImages;
    public Sprite[] FaceImages;
    public RawImage QuestItemCounter;

    public GameObject CustomerHead;
    public GameObject CustomerBody;
    public GameObject CustomerFace;

    public SpriteRenderer HeadRenderer;
    public SpriteRenderer FaceRenderer;
    public SpriteRenderer BodyRenderer;

    public static ShopManager instance;

    public PlayerStats TempPlayerStats;
    public GameObject PlayerStatsObject;


    private void Awake()
    {
       HeadRenderer = CustomerHead.GetComponent<SpriteRenderer>();
       BodyRenderer = CustomerBody.GetComponent<SpriteRenderer>();
       FaceRenderer = CustomerFace.GetComponent<SpriteRenderer>();

       FaceImages = Resources.LoadAll<Sprite>("Face");
       HeadImages = Resources.LoadAll<Sprite>("Head");
       TorsoImages = Resources.LoadAll<Sprite>("Torso");

       instance = this;

        PlayerStatsObject = GameObject.Find("PlayerStats");
        TempPlayerStats = PlayerStatsObject.GetComponent<PlayerStats>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            HeadRenderer.sprite = HeadImages[Random.Range(0, HeadImages.Length)];
            BodyRenderer.sprite = TorsoImages[Random.Range(0, TorsoImages.Length)];
            FaceRenderer.sprite = FaceImages[Random.Range(0, FaceImages.Length)];

        }

        if (TempPlayerStats.QuestComplete == true)
        {
            QuestItemCounter.color = new Color(1, 1, 0);
        }

        if (TempPlayerStats.QuestComplete == false)
        {
            QuestItemCounter.color = new Color(1, 1, 1);
        }
    }

    public void RandomiseCustomer()
    {
        HeadRenderer.sprite = HeadImages[Random.Range(0, HeadImages.Length)];
        BodyRenderer.sprite = TorsoImages[Random.Range(0, TorsoImages.Length)];
        FaceRenderer.sprite = FaceImages[Random.Range(0, FaceImages.Length)];
        TempPlayerStats.QuestComplete = false;

        //HeadRenderer.size = new Vector2(1, 1);
        //BodyRenderer.size = new Vector2(1, 1);
        //FaceRenderer.size = new Vector2(1, 1);
    }

 

    public void SceneSwapper()
    {
        SceneManager.UnloadSceneAsync("TheShop");
        SceneManager.LoadScene("ShopScene");
        
    }

}

