using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    [Header("Keyboard Input")]
    float horizontalInput;

    [Header("Game Start")]
    bool canMove;
    bool startGame;
    public TMP_Text startGameText;

    [Header("Durability")]
    public float maxDurability;
    public float wallDecreaseAmount;
    public float fishDecreaseAmount;
    float currentDurability;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startGameText.enabled = true;
        startGame = false;

        ResetGame();
    }

    void ResetGame()
    {
        currentDurability = maxDurability;
    }

    void EndGame()
    {
        QuestSystemPrototype.instance.QuestComplete = true;
        SceneManager.LoadScene("MainWorld");
    }

    void Update()
    {
        if (startGame == false)
        {
            WaitForGameStart();
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

        if (startGame == true)
        {
            HookFall();
        }
    }

    private void WaitForGameStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startGameText.enabled = false;
            startGame = true;
        }
    }

    private void KeyboardMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // rb.AddForceX(horizontalInput * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);

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

    private void WallDurability()
    {
        currentDurability -= wallDecreaseAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            EndGame();
        }
        if (collision.CompareTag("Wall"))
        {
            WallDurability();
        }
    }
}
