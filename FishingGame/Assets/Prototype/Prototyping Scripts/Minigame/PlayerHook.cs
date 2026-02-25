using UnityEngine;
using TMPro;

public class PlayerHook : MonoBehaviour
{
    [Header("Editables")]
    public float fallSpeed;
    public float moveSpeed;

    [Header("References")]
    private Rigidbody2D rb;

    [Header("Input")]
    [SerializeField] private bool mouseControl; // true = mouse  false = A/D

    [Header("Keyboard Input")]
    float horizontalInput;

    [Header("Game Start")]
    bool startGame;
    public TMP_Text startGameText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startGameText.enabled = true;
        startGame = false;
    }

    private void FixedUpdate()
    {
        if (mouseControl)
        {
            MouseMovement();
        }
        else
        {
            KeyboardMovement();
        }

        if (startGame == true)
        {
            HookFall();
        }
        else
        {
            WaitForGameStart();
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

    private void MouseMovement()
    {

    }

    private void KeyboardMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.AddForceX(horizontalInput * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void HookFall()
    {
        rb.AddForceY(-fallSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
