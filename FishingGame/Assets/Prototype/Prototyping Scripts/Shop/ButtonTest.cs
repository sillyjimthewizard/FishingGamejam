using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public PlayerStats PlayerStats;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ButtonClick()
    {
        //GameObject TempObject = GameObject.Find("PlayerStats");
        //PlayerStats = TempObject.GetComponent<PlayerStats>();

        ShopManager.instance.TempPlayerStats.QuestComplete = true;
        Debug.Log("YEs");
    }
}
