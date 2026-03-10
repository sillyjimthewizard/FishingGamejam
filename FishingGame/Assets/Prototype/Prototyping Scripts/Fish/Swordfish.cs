using System.Collections;
using UnityEngine;

public class Swordfish : MonoBehaviour
{
    [Header("Editables")]
    public float moveSpeed;

    [Header("Point References")]
    public Transform pointA;
    public Transform pointB;

    bool movingBack;

    private void Update()
    {
        CheckPos();
    }

    private void CheckPos()
    {
        if (!movingBack && transform.position != pointB.position) // start moving to B
        {
            StartCoroutine(StartBCharge());;
        }
        else if (movingBack && transform.position != pointA.position) // start moving to A
        {
            StartCoroutine(StartACharge());
        }
        else
        {
            movingBack = !movingBack;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    IEnumerator StartACharge()
    {
        yield return new WaitForSeconds(2f);
        transform.position = Vector2.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime); 
        yield break;
    }

    IEnumerator StartBCharge()
    {
        yield return new WaitForSeconds(2f);
        transform.position = Vector2.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);
        yield break;
    }
}
