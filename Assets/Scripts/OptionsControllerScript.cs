using UnityEngine;
using UnityEngine.UI;

public class OptionsControllerScript : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;
    private MusicPlayer musicPlayer;

    void Start()
    {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        if (musicPlayer == null)
        {
            Debug.LogError("No music player found in scene");
        }
        LoadFromPersistence();
    }

    public void LoadFromPersistence()
    {
        volumeSlider.value = PlayerPrefsWrapper.GetMasterVolumeOrDefault(0.8f);
        difficultySlider.value = PlayerPrefsWrapper.GetDifficulty();
        Debug.Log("Loaded options from persistence.  Vol: " + PlayerPrefsWrapper.GetMasterVolumeOrDefault(0.8f));
    }

    public void SaveAndExit()
    {
        PlayerPrefsWrapper.SetMasterVolume(volumeSlider.value);
        PlayerPrefsWrapper.SetDifficulty((int)difficultySlider.value);
        levelManager.LoadFirstLevel();

    }
    public void Update()
    {
        musicPlayer.SetVolume(volumeSlider.value);
    }

    static bool Within(float v, float min, float max)
    {
        return v >= min && v <= max;
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;

    }
}
