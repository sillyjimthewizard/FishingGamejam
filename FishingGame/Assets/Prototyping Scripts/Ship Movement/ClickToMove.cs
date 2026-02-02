using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Transform targetPoint;
    private NavMeshAgent agent;

    RaycastHit hit;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //targetPoint.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(targetPoint.position);
            //agent.SetDestination(targetPoint.position);

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }


}
