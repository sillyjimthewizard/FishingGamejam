using System.Collections;
using UnityEngine;

public class SquidDetection : MonoBehaviour
{
    public GameObject squidInk;
    public GameObject MainCamera;

    private void Awake()
    {
        squidInk.SetActive(false);
    }

    private void Start()
    {
        MainCamera = GameObject.Find("Main Camera (1)");
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
        Instantiate(squidInk, new Vector3 (MainCamera.transform.position.x, MainCamera.transform.position.y, 0), Quaternion.identity);
        yield return new WaitForSeconds(1.25f);
        squidInk.SetActive(false);
        yield break;
    }
}
