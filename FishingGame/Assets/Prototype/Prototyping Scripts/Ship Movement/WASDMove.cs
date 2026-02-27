using UnityEngine;
using UnityEngine.Rendering;

public class WASDMove : MonoBehaviour
{
    [Header("Editables")]
    private float currentSpeed;
    public float moveSpeed;
    public float backSpeed;
    public float turnSpeed;

    public float acceleration;
    public float deceleration;
    public float stoppingDistance;

    [Header("Input")]
    float horizontalInput;
    float verticalInput;

    bool braking;

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
        if (verticalInput == 1 || verticalInput == -1)
        {
            transform.Translate(Vector2.up * verticalInput * currentSpeed * Time.deltaTime);
        }
        else if (braking == true)
        {
            transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);

            if (currentSpeed == 0)
            {
                braking = false;
            }    
        }
        else
        {
            transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
        }

        // vertical input 1 is forwards, -1 is backwards
        if (verticalInput == 1) // Input: W
        {
            Acceleration();
            braking = false;
        }
        else if (verticalInput == -1) // Input: S
        {
            Deceleration();
            braking = true;
        }
        else // No Input
        {
            StoppingDistance();
        }
    }

    void Acceleration()
    {
        if (currentSpeed < moveSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (currentSpeed >= moveSpeed)
        {
            currentSpeed = moveSpeed;
        }
    }

    void Deceleration()
    {
        if (currentSpeed > backSpeed)
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        else if (currentSpeed < backSpeed)
        {
            currentSpeed += deceleration * Time.deltaTime;
        }
        else if (currentSpeed == backSpeed)
        {
            currentSpeed = backSpeed;
        }
    }

    void StoppingDistance()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= stoppingDistance * Time.deltaTime;
        }
        else
        {
            currentSpeed = 0;
        }
    }

    void Turning()
    {
        var rotation = horizontalInput * turnSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -rotation); // -rotation to invert the controls so d now goes right
    }
}
