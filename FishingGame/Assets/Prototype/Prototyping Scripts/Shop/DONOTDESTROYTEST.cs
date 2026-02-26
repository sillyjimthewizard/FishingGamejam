using UnityEngine;
using UnityEngine.SceneManagement;

public class DONOTDESTROYTEST : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameObject[] Faces = GameObject.FindGameObjectsWithTag("Face");
        GameObject[] Heads = GameObject.FindGameObjectsWithTag("Head");
        GameObject[] Bodys = GameObject.FindGameObjectsWithTag("Body");
        GameObject[] TextLocation = GameObject.FindGameObjectsWithTag("Location");
        GameObject[] TextDialogue = GameObject.FindGameObjectsWithTag("Dialogue");

      



        if (Faces.Length > 1 && this.tag == "Face")
        {
            Destroy(this.gameObject);
        }
        if (Heads.Length > 1 && this.tag == "Head")
        {
            Destroy(this.gameObject);
        }
        if (Bodys.Length > 1 && this.tag == "Body")
        {
            Destroy(this.gameObject);
        }
        if (TextLocation.Length > 1 && this.tag == "Location")
        {
            Destroy(this.gameObject);
        }
        if (TextDialogue.Length > 1 && this.tag == "Dialogue")
        {
            Destroy(this.gameObject);
        }
       

        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {

        GameObject[] DND_UIs = GameObject.FindGameObjectsWithTag("DND_UI");
        if (DND_UIs.Length > 1 && this.tag == "DND_UI")
        {
            Destroy(this.gameObject);
        }
    }
    
}
