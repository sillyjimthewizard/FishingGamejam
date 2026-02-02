using UnityEngine;

public class DONOTDESTROYTEST : MonoBehaviour
{

    public int banana; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("shop");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
