using Unity.VisualScripting;
using UnityEngine;

public class BasicCod : MonoBehaviour
{
    [Header("Editables")]
    public float moveSpeed;

    [Header("Game Reset")]
    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    void GameReset()
    {
        if (MinigameManager.instance.resetGame == true)
        {
            transform.position = startPos;
        }
    }    

    void Update()
    {
        GameReset();
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void WallHit()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            WallHit();
        }
    }
}
