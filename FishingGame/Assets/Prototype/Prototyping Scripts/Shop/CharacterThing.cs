using UnityEngine;
using UnityEngine.UI;

public class CharacterThing : MonoBehaviour
{

    public Texture[] TorsoImages;
    public Texture[] HeadImages;
    public Texture[] FaceImages;

    public RawImage CustomerHead;
    public RawImage CustomerBody;
    public RawImage CustomerFace;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            CustomerHead.texture = HeadImages[Random.Range(0, HeadImages.Length)];
            CustomerBody.texture = TorsoImages[Random.Range(0, HeadImages.Length)];
            CustomerFace.texture = FaceImages[Random.Range(0, HeadImages.Length)];
        }
    }

    public void RandomiseCustomer()
    {
        CustomerHead.texture = HeadImages[Random.Range(0, HeadImages.Length)];
        CustomerBody.texture = TorsoImages[Random.Range(0, HeadImages.Length)];
        CustomerFace.texture = FaceImages[Random.Range(0, HeadImages.Length)];
    }

}
