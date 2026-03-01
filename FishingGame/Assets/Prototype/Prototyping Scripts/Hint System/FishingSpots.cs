 using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingSpots : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay2D()
    {
        if (gameObject.name == QuestSystemPrototype.instance.CurrentQuest.Location && Input.GetKeyDown("e"))
        {
            Debug.Log("start fishing");
            QuestSystemPrototype.instance.QuestComplete = true;
        }

        if (gameObject.name == "BackToShop" && Input.GetKeyDown("e"))
        {
         //  QuestSystemPrototype.instance.StartCoroutine(RefreshTimer());
            SceneManager.UnloadSceneAsync("MainWorld");
            SceneManager.LoadScene("TheShop");

        }
    }
}
