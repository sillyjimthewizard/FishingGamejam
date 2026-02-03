using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.WSA;
using static UnityEditor.MaterialProperty;

public class CharacterThing : MonoBehaviour
{

    public Texture[] TorsoImages;
    public Texture[] HeadImages;
    public Texture[] FaceImages;

    public RawImage CustomerHead;
    public RawImage CustomerBody;
    public RawImage CustomerFace;



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

