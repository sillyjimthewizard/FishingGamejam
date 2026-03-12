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
    }

    public void ChooseQuotes()
    {
        RandomFunFact.text = FunFacts[Random.Range(0, FunFacts.Length)];

    }
}
