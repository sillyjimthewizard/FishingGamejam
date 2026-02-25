 using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingSpots : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        if (gameObject.name == QuestSystemPrototype.instance.CurrentQuest.Location)
        {
            Debug.Log("start fishing");
            QuestSystemPrototype.instance.QuestComplete = true;
        }

        if (gameObject.name == "BackToShop")
        {
         //  QuestSystemPrototype.instance.StartCoroutine(RefreshTimer());
            SceneManager.UnloadSceneAsync("MainWorld");
            SceneManager.LoadScene("TheShop");

        }
    }
}
