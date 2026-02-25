using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public bool QuestComplete;


    void Awake()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("shop");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
