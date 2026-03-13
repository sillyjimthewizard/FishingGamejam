using TMPro;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    public bool startGame;
    public bool resetGame;
    public bool resetCamera;

    public string[] FunFacts;

    public TMP_Text RandomFunFact;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        startGame = false;
        resetGame = false;

        FunFacts = new string[] {
        "Microplastics have been found in newborn children",
        "Over 5.25 trillion pieces of trash is in the ocean (based on 2023)",
        "the trash in the ocean weighs more than 11 statues of liberty",
        "Plastic has been found in the deepest parts of our ocean" };

    }

    public void ChooseQuotes()
    {
        
        RandomFunFact.text = FunFacts[Random.Range(0, FunFacts.Length)];

    }
}
