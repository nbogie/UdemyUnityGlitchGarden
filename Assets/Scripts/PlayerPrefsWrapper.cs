using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerPrefsWrapper
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string MAX_UNLOCKED_LEVEL_KEY = "max_unlocked_level";
    const string DIFFICULTY_KEY = "difficulty";

    public static void SetMasterVolume(float volume)
    {
        if (volume > 1f || volume < 0f)
        {
            Debug.LogError("MasterVolume out of range: " + volume);
        }
        else
        {
            Debug.Log("Saving MasterVolume: " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
    }

    public static float GetMasterVolumeOrDefault(float defaultValue)
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, defaultValue);
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

    public static void SetDifficulty(int value)
    {
        if (Within(value, 1, 3))
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, value);
            Debug.Log("saved difficulty: " + value);
        }
        else
        {
            Debug.LogError("Difficulty value outwith range: " + value);
        }
    }

    public static void UnlockLevel(int level)
    {
        PlayerPrefs.SetInt(MAX_UNLOCKED_LEVEL_KEY, level);
    }

    public static bool IsLevelUnlocked(int levelNumber)
    {
        Debug.Log("isLevelUnlocked(): Don't call this frequently");
        int numScenesInBuild = SceneManager.sceneCountInBuildSettings - 2;
        if (levelNumber > numScenesInBuild)
        {
            Debug.LogError("No such level in build: " + levelNumber + " .  Would be scene " + (levelNumber + 2));
        }
        return PlayerPrefs.GetInt(MAX_UNLOCKED_LEVEL_KEY) >= levelNumber;
    }

    private static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);

    }

    public static bool GetBool(string pref)
    {
        if (PlayerPrefs.HasKey(pref))
        {
            return PlayerPrefs.GetInt(pref) == 1;
        }
        else
        {
            return false;
        }
    }
    private static bool Within(float v, float min, float max)
    {
        return v >= min && v <= max;
    }

}
