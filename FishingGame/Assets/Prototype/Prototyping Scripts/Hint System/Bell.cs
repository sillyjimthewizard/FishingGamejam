using UnityEngine;

public class Bell : MonoBehaviour
{

    public GameObject QuestSystem;
    public QuestSystemPrototype QuestSystemPrototype;
    public AudioClip BellSound;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Refresh()
    {
        S_SoundManager.instance.PlaySound(BellSound, 0.4f);
        QuestSystem = GameObject.Find("QuestManager");
        QuestSystemPrototype = QuestSystem.GetComponent<QuestSystemPrototype>();
        if (QuestSystemPrototype.QuestComplete == true ) {
            QuestSystemPrototype.GetQuest();
           
        }
    }
}
