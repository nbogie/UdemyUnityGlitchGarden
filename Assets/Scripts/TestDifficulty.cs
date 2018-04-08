using UnityEngine;

public class TestDifficulty : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("Difficulty: " + PlayerPrefsWrapper.GetDifficulty());
        Debug.Log("Master Volume: " + PlayerPrefsWrapper.GetMasterVolumeOrDefault(0.8f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
