using Unity.VisualScripting;
using UnityEngine;

public class BasicCod : MonoBehaviour
{
    [Header("Editables")]
    public float moveSpeed;

    void Update()
    {
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
