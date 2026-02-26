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
    [SerializeField] private Vector3[] points;
    [SerializeField] private GameObject destination;

    [Header("Side Detection")]
    [SerializeField] private GameObject[] sidePoints;

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
            StartCoroutine(FollowArc(playerPos, points[0], points[1], turningArc, duration));

            Debug.Log("Mouse Pos: " + mousePos);
        }
    }

    IEnumerator PointSet()
    {
        points[0] = gameObject.transform.position; // player pos
        points[1] = mousePos; // mouse pos (destination)
        destination.transform.position = points[1];
        yield break;
    }

    IEnumerator DetermineDuration()
    {
        // find distance
        float distance = Vector2.Distance(points[0], points[1]);

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
            destination.SetActive(true);
            TurnShip();
            travelling = true;
            float angle = startAngle + progress * travel;
            player.position = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * absRadius;
            progress += Time.deltaTime / duration;
            yield return null;
        } while (progress < 1f);

        destination.SetActive(false);
        travelling = false;
        player.position = end;
    }

    void SideDetection()
    {

    }

    void TurnShip()
    {
        var newRotation = Quaternion.LookRotation(transform.position - points[1], Vector3.forward);
        newRotation.x = transform.rotation.x;
        newRotation.y = transform.rotation.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turnSpeed);
    }
}