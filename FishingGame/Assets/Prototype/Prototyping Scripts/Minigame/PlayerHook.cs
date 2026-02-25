using UnityEngine;
using TMPro;

public class PlayerHook : MonoBehaviour
{
    [Header("Editables")]
    public float fallSpeed;
    public float moveSpeed;

    [Header("Input")]
    [SerializeField] private bool mouseControl; // true = mouse  false = A/D

    [Header("Keyboard Input")]
    float horizontalInput;

    [Header("Game Start")]
    bool startGame;
    public TMP_Text startGameText;

    private void Start()
    {
        startGameText.enabled = true;
        startGame = false;
    }

    void Update()
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

        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
    }

    private void HookFall()
    {
        transform.Translate(Vector2.down * fallSpeed *  Time.deltaTime);
    }
}
