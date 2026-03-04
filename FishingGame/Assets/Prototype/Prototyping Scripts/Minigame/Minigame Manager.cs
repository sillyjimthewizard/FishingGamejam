using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    public bool startGame;
    public bool resetGame;
    public bool resetCamera;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        startGame = false;
        resetGame = false;
    }
}
