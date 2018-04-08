using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolumeLevel : MonoBehaviour
{

    void Start()    
    {
        MusicPlayer musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        musicPlayer.SetVolume(PlayerPrefsWrapper.GetMasterVolumeOrDefault(0.8f));

    }

}
