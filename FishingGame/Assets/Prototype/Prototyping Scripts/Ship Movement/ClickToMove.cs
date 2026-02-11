using System;
using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ClickToMove : MonoBehaviour
{
    [Header("Editables")]
    public float speed;
    public float turningArc;

    private float duration;

    [Header("Rotation")]
    Vector3 lastPosition;
    Vector3 movementDirection;

    [Header("Destination")]
    private Vector2 mousePos;
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3[] point;
    [SerializeField] private GameObject destination;

    private void Update()
    {
        FindMousePos();
        TurnShip();
    }

    void FindMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            StartCoroutine(PointSet());
            StartCoroutine(DetermineDuration());
            StartCoroutine(FollowArc(playerPos, point[0], point[1], turningArc, duration));

            Debug.Log(mousePos);
        }
    }

    IEnumerator PointSet()
    {
        point[0] = gameObject.transform.position; // player pos
        point[1] = mousePos; // mouse pos (destination)
        yield break;
    }

    IEnumerator DetermineDuration()
    {
        // find distance
        float distance = Vector2.Distance(point[0], point[1]);

        // (formula) time equals distance over time
        duration = distance / speed;

        yield break;
    }

    IEnumerator FollowArc(
        Transform player,
        Vector2 start,
        Vector2 end,
        float radius, // Set this to negative if you want to flip the arc.
        float duration)
    {

        Vector2 difference = end - start;
        float span = difference.magnitude;

        // Override the radius if it's too small to bridge the points.
        float absRadius = Mathf.Abs(radius);
        if (span > 2f * absRadius)
            radius = absRadius = span / 2f;

        Vector2 perpendicular = new Vector2(difference.y, -difference.x) / span;
        perpendicular *= Mathf.Sign(radius) * Mathf.Sqrt(radius * radius - span * span / 4f);

        Vector2 center = start + difference / 2f + perpendicular;

        Vector2 toStart = start - center;
        float startAngle = Mathf.Atan2(toStart.y, toStart.x);

        Vector2 toEnd = end - center;
        float endAngle = Mathf.Atan2(toEnd.y, toEnd.x);

        // Choose the smaller of two angles separating the start & end
        float travel = (endAngle - startAngle + 5f * Mathf.PI) % (2f * Mathf.PI) - Mathf.PI;

        float progress = 0f;
        do
        {
            float angle = startAngle + progress * travel;
            player.position = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * absRadius;
            progress += Time.deltaTime / duration;
            yield return null;
        } while (progress < 1f);

        player.position = end;
    }

    void TurnShip()
    {
        //float threshold = Single.Epsilon;
        //float turnSpeed = 3f;
        //float step = turnSpeed * Time.deltaTime;
        //while (Vector3.Angle(point[0], point[1]) > threshold)
        //{
        //    Vector3 newDir = Vector3.RotateTowards(point[0], point[1], step, 0);
        //    transform.rotation = Quaternion.LookRotation(newDir);
        //    yield return null;
        //}

        float turnSpeed = 5f;

        var newRotation = Quaternion.LookRotation(transform.position - point[1], Vector3.forward);
        newRotation.x = 0f;
        newRotation.y = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turnSpeed);
    }
}
