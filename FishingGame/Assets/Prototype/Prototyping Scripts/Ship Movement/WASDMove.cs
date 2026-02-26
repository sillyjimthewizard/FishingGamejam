using UnityEngine;

public class WASDMove : MonoBehaviour
{
    [Header("Editables")]
    public float moveSpeed;
    public float turnSpeed;

    [Header("Input")]
    float horizontalInput;
    float verticalInput;

    [Header("References")]
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
        VerticalMovement();
        Turning();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void VerticalMovement()
    { 
        transform.Translate(Vector2.up * verticalInput * moveSpeed * Time.deltaTime);

        // rb.AddForce(transform.up * verticalInput * moveSpeed * Time.deltaTime);
    }

    void Turning()
    {
        var rotation = horizontalInput * turnSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -rotation); // -rotation to invert the controls so d now goes right
    }
}
