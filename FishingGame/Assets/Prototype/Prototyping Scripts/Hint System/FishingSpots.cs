using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingSpots : MonoBehaviour
{

    public GameObject QuestSystem;
    public QuestSystemPrototype QuestSystemPrototype;
    public float degreesPerSecond = 2f;

    public TMP_Text tooltip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QuestSystem = GameObject.Find("QuestManager");
        QuestSystemPrototype = QuestSystem.GetComponent<QuestSystemPrototype>();
        
    }
    private void Update()
    {
        if (gameObject.name == QuestSystemPrototype.CurrentQuest.Location)
        {
            transform.Rotate(0, 0, degreesPerSecond * Time.deltaTime);
        }
    }



    // Update is called once per frame
    //void OnTriggerStay2D()
    //{
    //    if (Input.GetKeyDown("e"))
    //    {
    //        Debug.Log("E clicked");

    //    }

    //    if (Input.GetKeyDown("e") && gameObject.name == QuestSystemPrototype.CurrentQuest.Location && QuestSystemPrototype.QuestComplete == false)
    //    {
    //        QuestSystemPrototype.PlayerPosition = this.transform.position;

    //        Debug.Log("start fishing");
    //        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("MainWorld");
    //        SceneManager.LoadScene(QuestSystemPrototype.CurrentQuest.ObjectWanted);
    //    }

    //    if (gameObject.name == "BackToShop" && Input.GetKeyDown("e"))
    //    {
    //        QuestSystemPrototype.PlayerPosition = this.transform.position;
    //        //  QuestSystemPrototype.instance.StartCoroutine(RefreshTimer());
    //        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("MainWorld");
    //        SceneManager.LoadScene("TheShop");

    //    }
    //}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tooltip.enabled = true;

            Debug.Log("Player Found");
            if (Input.GetKeyDown(KeyCode.E) && this.gameObject.name == QuestSystemPrototype.CurrentQuest.Location && QuestSystemPrototype.QuestComplete == false)
            {
                QuestSystemPrototype.PlayerPosition = this.transform.position;

                Debug.Log("start fishing");
                // UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("MainWorld");
                SceneManager.LoadScene(QuestSystemPrototype.CurrentQuest.ObjectWanted);
            }
            else if (this.gameObject.name == "BackToShop" && Input.GetKeyDown(KeyCode.E))
            {
                QuestSystemPrototype.PlayerPosition = this.transform.position;
                // QuestSystemPrototype.instance.StartCoroutine(RefreshTimer());
                // UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("MainWorld");
                SceneManager.LoadScene("TheShop");

            }
        }
        else
        {
            tooltip.enabled = false;
        }
    }
}
