using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelAnnounceScript : MonoBehaviour
{
    Text levelText;
    public float fadeTime = 1f;
    void Start()
    {
        levelText = GetComponent<Text>();
        levelText.enabled = true;
        int levelNumber = SceneManager.GetActiveScene().buildIndex - 2;
        levelText.text = "Level " + levelNumber + "...";
        //not necessary
        ResetAlpha();

    }

    void ResetAlpha()
    {
        Color newColor = levelText.color;
        newColor.a = 1f;
        levelText.color = newColor;

    }
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeTime)
        {
            Color newColor = levelText.color;
            newColor.a -= Time.deltaTime / fadeTime;
            levelText.color = newColor;
        }
        else
        {
            levelText.enabled = false;
        }
    }
}
