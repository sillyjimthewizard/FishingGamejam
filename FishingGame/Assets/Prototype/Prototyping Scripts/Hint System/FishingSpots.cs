 using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingSpots : MonoBehaviour
{

    public GameObject QuestSystem;
    public QuestSystemPrototype QuestSystemPrototype;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QuestSystem = GameObject.Find("QuestManager");
        QuestSystemPrototype = QuestSystem.GetComponent<QuestSystemPrototype>();
        
    }

    // Update is called once per frame
    void OnTriggerStay2D()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("E clicked");
        
        }

        if (Input.GetKeyDown("e") && gameObject.name == QuestSystemPrototype.CurrentQuest.Location && QuestSystemPrototype.QuestComplete == false)
        {
            Debug.Log("start fishing");
            SceneManager.LoadScene("Tunnelling");
        }

        if (gameObject.name == "BackToShop" && Input.GetKeyDown("e"))
        {
         //  QuestSystemPrototype.instance.StartCoroutine(RefreshTimer());
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("MainWorld");
            SceneManager.LoadScene("TheShop");

        }
    }
}
