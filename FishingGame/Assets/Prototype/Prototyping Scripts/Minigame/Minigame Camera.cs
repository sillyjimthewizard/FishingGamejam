using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class MinigameCamera : MonoBehaviour
{
    [Header("Editables")]
    public float followSpeed;
    public float cameraDamp;

    [Header("References")]
    public GameObject player;

    [Header("Camera Offsets")]
    public float yOffset;
    float zOffset = -10;

    Vector3 currentVelocity;
    bool startCameraFollow;
    bool canMove;

    private void Awake()
    {
        startCameraFollow = false;
    }

    private void Update()
    {
        // checking if the bool it is setting true is false prevents unnessecary checks every frame
        if (Input.GetKeyDown(KeyCode.Space) && startCameraFollow == false)
        {
            startCameraFollow = true;
        }
    }

    void FixedUpdate()
    {
        if (startCameraFollow)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new(0, player.transform.position.y - yOffset, zOffset), ref currentVelocity, cameraDamp, followSpeed);
        }
    }
}
