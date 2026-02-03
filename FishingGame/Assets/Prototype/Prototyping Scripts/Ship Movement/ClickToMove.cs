using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Transform targetPoint;
    private NavMeshAgent agent;
    public LayerMask groundLayer;

    Ray destination;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ClickMove();
    }

    // left clicking finds the mouse pos relative to the players screen
    // setting the destination to the pos it finds

    Vector2 turningPoint;
    Vector2 origin;
    float angleToP;
    float initialDirection;
    private void ClickMove()
    {
        if (Input.GetMouseButton(0))
        {

        }

        //turningPoint = gameObject.transform.position;
        //Vector2 r = turningPoint - origin;

        //destination = new(50, -5);

        //angleToP = initialDirection - 90f;
        //turningPoint.x = origin.x + r.x * Mathf.Cos(angleToP);
        //turningPoint.y = origin.y + r.y * Mathf.Sin(angleToP);

        //float dx = destination.x - turningPoint.x;
        //float dy = destination.y - turningPoint.y;
        //float h = Mathf.Sqrt(dx * dx + dy * dy);

        //if (h < r.x || h < r.y)
        //{
        //    return;
        //}
        //else
        //{
        //    Vector2 d = new(dx, dy);
        //    d = new(Mathf.Sqrt(h * h - r.x * r.x), Mathf.Sqrt(h * h - r.y * r.y));
        //    Vector2 theta = new(Mathf.Acos(r.x / h), Mathf.Acos(r.y / h));

        //    float phi = Mathf.Atan(dy / dx);
        //    Vector2 Q = new(turningPoint.x + r.x * Mathf.Cos(phi + theta.x), turningPoint.y + r.y * Mathf.Sin(phi + theta.y));

        //    agent.SetDestination(Q);

    }
}