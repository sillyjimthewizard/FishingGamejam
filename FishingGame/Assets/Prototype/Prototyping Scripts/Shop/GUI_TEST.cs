using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_TEST : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnGUI()
    {
        int xCenter = (Screen.width / 2);
        int yCenter = (Screen.height / 2);
        int width = 400;
        int height = 120;

        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
        fontSize.fontSize = 32;

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "ShopScene")
        {
            // Show a button to allow scene2 to be switched to.
            if (GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "Load second scene", fontSize))
            {
                SceneManager.LoadScene("SceneTest");
            }
        }
        else
        {
            // Show a button to allow scene1 to be returned to.
            if (GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "Return to first scene", fontSize))
            {
                SceneManager.LoadScene("ShopScene");
            }
        }
    }
}
