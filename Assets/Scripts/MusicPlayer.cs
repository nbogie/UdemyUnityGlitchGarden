using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] tracks;

    private AudioSource source;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int ix = scene.buildIndex;
        if (ix < tracks.Length)
        {
            AudioClip clip = tracks[ix];
            if (!source)
            {
                source = GetComponent<AudioSource>();
            }

            if (source.isPlaying)
            {
                source.Stop();
            }
            source.clip = clip;
            source.Play();
        }
    }
    public void SetVolume(float v){
        if (source && source.isPlaying){
            source.volume = v;
        }

    }
}
