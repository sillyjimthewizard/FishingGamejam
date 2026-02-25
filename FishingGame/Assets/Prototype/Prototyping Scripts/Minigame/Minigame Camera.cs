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

    private void Awake()
    {
        startCameraFollow = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startCameraFollow = true;
        }

        if (startCameraFollow)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new(0, player.transform.position.y - yOffset, zOffset), ref currentVelocity, cameraDamp, followSpeed);
        }
    }
}
