using System.Collections;
using UnityEngine;

public class SquidDetection : MonoBehaviour
{
    public GameObject squidInk;
    public GameObject MainCamera;

    private void Awake()
    {
        //squidInk.SetActive(false);
    }

    private void Start()
    {
        MainCamera = GameObject.Find("MainCamera");
        squidInk = Resources.Load<GameObject>("SquidInk/Ink");
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
        GameObject Squidink2 = Instantiate(squidInk, new Vector3 (MainCamera.transform.position.x, MainCamera.transform.position.y, 1), Quaternion.identity);
        Squidink2.transform.SetParent(MainCamera.transform);
        yield return new WaitForSeconds(1.25f);
        Destroy(Squidink2);
        yield break;
    }
}
