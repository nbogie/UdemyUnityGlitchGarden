using UnityEngine;
using UnityEngine.UI;

public class GameTimerSlider : MonoBehaviour
{
    public int maxTimeForLevel;
    private Slider slider;
    public Text winText;

    private LevelManager levelManager;

    void Start()
    {
        slider = GetComponent<Slider>();
        float timeRemaining = maxTimeForLevel;
        levelManager = FindObjectOfType<LevelManager>();
        UpdateSlider(timeRemaining);
        winText.enabled = false;

    }
    void UpdateSlider(float remaining)
    {
        float remainingAsFraction = 1 - (remaining / maxTimeForLevel);
        slider.value = remainingAsFraction;
    }

    void Update()
    {
        float timeRemaining = maxTimeForLevel - Time.timeSinceLevelLoad;
        UpdateSlider(timeRemaining);
        if (timeRemaining <= 0)
        {
            //TODO: don't allow game loss once we start this rolling
            winText.text = "Level Complete!";
            winText.enabled = true;
            Invoke("ProgressToNextLevel", 2);

        }

    }
    void ProgressToNextLevel()
    {
        //levelManager.AnnounceWinLevel();
        //TODO: check we haven't lost!
        levelManager.LoadNextScene();
    }
}
