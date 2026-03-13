using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHook : MonoBehaviour
{
    [Header("Editables")]
    public float fallSpeed;
    public float boostSpeed;
    public float slowSpeed;
    public float moveSpeed;

    float currentFallSpeed;

    [Header("References")]
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Keyboard Input")]
    float horizontalInput;

    [Header("Game Start")]
    private Vector2 startPos;
    bool canMove;
    public TMP_Text startGameText;

    [Header("Durability")]
    public float maxDurability;
    public float wallDecreaseAmount;
    public float fishDecreaseAmount;
    float currentDurability;

    [Header("GameObjects")]
    public GameObject FishingUI;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        startPos = transform.position;
        currentDurability = maxDurability;
    }

    private void Start()
    {
        startGameText.enabled = true;
    }

    IEnumerator PlayerDeath()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        QuestSystemPrototype.instance.QuestComplete = true;
        SceneManager.LoadScene("MainWorld");
    }

    void Update()
    {
        Durability();

        if (MinigameManager.instance.startGame == false)
        {
            WaitForGameStart();
        }
        if (MinigameManager.instance.resetGame == true)
        {
            StartCoroutine(PlayerDeath());
        }

        // checking if the bool it is setting true is false prevents unnessecary checks every frame
        if (transform.position.y <= -3 && canMove == false)
        {
            canMove = true;
        }

        if (canMove == true)
        {
            KeyboardMovement();
        }

        if (MinigameManager.instance.startGame == true)
        {
            HookFall();
        }
    }

    private void WaitForGameStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startGameText.enabled = false;
            MinigameCamera.instance.startCameraFollow = true;
            MinigameManager.instance.startGame = true;
        }
    }

    private void KeyboardMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.position += Vector2.right * horizontalInput * moveSpeed * Time.deltaTime;
    }

    private void HookFall()
    {
        rb.position -= Vector2.up * currentFallSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
        {
            currentFallSpeed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            currentFallSpeed = slowSpeed;
        }
        else
        {
            currentFallSpeed = fallSpeed;
        }
    }

    private void Durability()
    {
        if (currentDurability <= 0)
        {
            currentDurability = 0;
            StartCoroutine(PlayerDeath());
        }
    }

    private void WallDurability()
    {
        currentDurability -= wallDecreaseAmount * Time.deltaTime;
    }

    private void FishDurability()
    {
        currentDurability -= fishDecreaseAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            QuestSystemPrototype.instance.SceneCheckWorld = true;
            //EndGame();
            StartUI();
        }
        if (collision.CompareTag("Fish"))
        {
            FishDurability();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallDurability();
        }
    }

    public void StartUI()
    {
        FishingUI.SetActive(true);
        MinigameManager.instance.ChooseQuotes();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
