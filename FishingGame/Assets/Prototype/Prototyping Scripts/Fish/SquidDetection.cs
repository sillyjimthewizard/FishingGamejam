using System.Collections;
using UnityEngine;

public class SquidDetection : MonoBehaviour
{
    public GameObject squidInk;

    private void Awake()
    {
        squidInk.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SquidInterference());
        }
    }

    IEnumerator SquidInterference()
    {
        squidInk.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        squidInk.SetActive(false);
        yield break;
    }
}
