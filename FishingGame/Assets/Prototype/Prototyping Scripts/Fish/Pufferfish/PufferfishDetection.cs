using UnityEngine;

public class PufferfishDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PufferfishExpand.Instance.expand = true;
        }
    }
}
