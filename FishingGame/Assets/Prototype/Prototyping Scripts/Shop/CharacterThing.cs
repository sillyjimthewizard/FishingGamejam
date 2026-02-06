using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.WSA;
using static UnityEditor.MaterialProperty;

public class CharacterThing : MonoBehaviour
{

    public Sprite[] TorsoImages;
    public Sprite[] HeadImages;
    public Sprite[] FaceImages;

    public GameObject CustomerHead;
    public GameObject CustomerBody;
    public GameObject CustomerFace;

    public SpriteRenderer HeadRenderer;
    public SpriteRenderer FaceRenderer;
    public SpriteRenderer BodyRenderer;


    private void Start()
    {
       HeadRenderer = CustomerHead.GetComponent<SpriteRenderer>();
       BodyRenderer = CustomerBody.GetComponent<SpriteRenderer>();
       FaceRenderer = CustomerFace.GetComponent<SpriteRenderer>();

       FaceImages = Resources.LoadAll<Sprite>("Face");
       HeadImages = Resources.LoadAll<Sprite>("Head");
       TorsoImages = Resources.LoadAll<Sprite>("Torso");

      

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            HeadRenderer.sprite = HeadImages[Random.Range(0, HeadImages.Length)];
            BodyRenderer.sprite = TorsoImages[Random.Range(0, TorsoImages.Length)];
            FaceRenderer.sprite = FaceImages[Random.Range(0, FaceImages.Length)];

            HeadRenderer.size = new Vector2(1, 1);
            BodyRenderer.size = new Vector2(1, 1);
            FaceRenderer.size = new Vector2(1, 1);

        }
    }

    public void RandomiseCustomer()
    {
        HeadRenderer.sprite = HeadImages[Random.Range(0, HeadImages.Length)];
        BodyRenderer.sprite = TorsoImages[Random.Range(0, TorsoImages.Length)];
        FaceRenderer.sprite = FaceImages[Random.Range(0, FaceImages.Length)];

        HeadRenderer.size = new Vector2(1, 1);
        BodyRenderer.size = new Vector2(1, 1);
        FaceRenderer.size = new Vector2(1, 1);
    }

}

