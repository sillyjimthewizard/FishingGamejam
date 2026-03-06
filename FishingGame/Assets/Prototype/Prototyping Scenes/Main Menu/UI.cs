using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public bool TitleScreenSkipped;
    public GameObject Title;
    public GameObject main;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    

    public void Play()
    {
        SceneManager.LoadScene("TheShop");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Options()
    {
        Application.OpenURL("https://i1.sndcdn.com/artworks-000664006093-hhm0rf-t500x500.jpg");

    }
}
