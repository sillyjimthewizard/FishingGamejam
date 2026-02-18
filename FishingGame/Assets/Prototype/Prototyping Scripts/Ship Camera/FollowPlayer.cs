using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target; // player

    Vector3 offset = new(0, 0, -10);
    Vector3 currentVelocity;

    [Header("Editables")]
    public float followSpeed;
    public float cameraDamp;

    void Update()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + offset, ref currentVelocity, cameraDamp, followSpeed);
    }
}
