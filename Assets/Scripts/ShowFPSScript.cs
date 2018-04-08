using UnityEngine;
using UnityEngine.UI;

public class ShowFPSScript : MonoBehaviour
{
    public Text fpsText;

    void Update()
    {
        float smoothFPS = 1 / Time.smoothDeltaTime;
        fpsText.text = "FPS: " + Mathf.Round(smoothFPS);
    }
}
