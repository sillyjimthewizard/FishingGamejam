using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class MinigameCamera : MonoBehaviour
{
    public static MinigameCamera instance;

    [Header("Editables")]
    public float followSpeed;
    public float cameraDamp;

    [Header("References")]
    public GameObject player;

    [Header("Camera Offsets")]
    public float yOffset;
    float zOffset = -10;

    Vector3 currentVelocity;
    public bool startCameraFollow;

    private void Awake()
    {
        instance = this;
        startCameraFollow = false;
    }


    void FixedUpdate()
    {
        if (startCameraFollow == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new(0, player.transform.position.y - yOffset, zOffset), ref currentVelocity, cameraDamp, followSpeed);
        }
    }
}
