using System.Collections;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    [Header("Editables")]
    public float speed;
    public float turningArc;
    public float turnSpeed;

    [Header("Destination")]
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3[] point;

    private bool travelling;
    private Vector2 mousePos;
    private float duration;

    private void Update()
    {
        FindMousePos();
    }

    void FindMousePos()
    {
        if (Input.GetMouseButtonDown(0) && travelling == false)
        {
            StopAllCoroutines();
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            StartCoroutine(PointSet());
            StartCoroutine(DetermineDuration());
            StartCoroutine(FollowArc(playerPos, point[0], point[1], turningArc, duration));

            Debug.Log("Mouse Pos: " + mousePos);
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
            TurnShip();
            travelling = true;
            float angle = startAngle + progress * travel;
            player.position = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * absRadius;
            progress += Time.deltaTime / duration;
            yield return null;
        } while (progress < 1f);

        travelling = false;
        player.position = end;
    }

    void TurnShip()
    {
        var newRotation = Quaternion.LookRotation(transform.position - point[1], Vector3.forward);
        newRotation.x = transform.rotation.x;
        newRotation.y = transform.rotation.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turnSpeed);
    }
}