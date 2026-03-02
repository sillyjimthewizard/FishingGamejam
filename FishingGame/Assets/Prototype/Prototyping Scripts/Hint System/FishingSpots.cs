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
        if (Input.GetKeyDown("e") && gameObject.name == QuestSystemPrototype.instance.CurrentQuest.Location && QuestSystemPrototype.instance.QuestComplete == false)
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
