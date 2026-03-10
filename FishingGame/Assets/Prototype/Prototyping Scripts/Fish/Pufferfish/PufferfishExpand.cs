using System.Collections;
using UnityEngine;

public class PufferfishExpand : MonoBehaviour
{
    public static PufferfishExpand Instance;

    public Transform detectionZone;

    public bool expand;

    private Transform originalScale;

    private void Awake()
    {
        Instance = this;

        expand = false;
    }

    private void Start()
    {
        originalScale.transform.localScale = transform.localScale;
    }

    private void Update()
    {
        if (expand == true)
        {
            StartCoroutine(ChargeExpand());
        }
        else
        {
            transform.localScale = new(1, 1, 1);
        }
    }

    IEnumerator ChargeExpand()
    {
        yield return new WaitForSeconds(0.9f);
        transform.localScale = new(4, 4, 4);
        yield break;
    }
}
