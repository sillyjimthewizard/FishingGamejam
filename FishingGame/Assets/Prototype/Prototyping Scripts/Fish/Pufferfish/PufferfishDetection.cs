using UnityEngine;

public class PufferfishDetection : MonoBehaviour
{
    public PufferfishExpand pufferfishMainScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pufferfishMainScript.expand = true;
        }
    }
}
