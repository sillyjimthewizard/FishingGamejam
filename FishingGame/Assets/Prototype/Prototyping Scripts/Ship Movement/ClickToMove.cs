using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Transform targetPoint;
    private NavMeshAgent agent;
    public LayerMask groundLayer;

    Ray ray;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        agent.SetDestination(ray.origin);
    }
}
