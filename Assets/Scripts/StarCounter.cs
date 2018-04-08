using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text), typeof(AudioSource))]
public class StarCounter : MonoBehaviour {

    private Text text;
    private int count;
    public int startingCount = 100;
    private AudioSource audioSource;

	void Start () {
        text = GetComponent<Text>();
        count = startingCount;
        UpdateText();
        audioSource = GetComponent<AudioSource>();
	}

    void UpdateText(){
        text.text = count.ToString();
    }

    public void AddStars()
    {
        audioSource.Play();
        count += 10;
        UpdateText();
    }

    public bool TryToUseStars(int cost)
    {
        if (count >= cost)
        {
            count -= cost;
            UpdateText();
            //TODO: spawn a temporary "-20" throwout to show the expenditure.
            return true;
        }
        else
        {
            //TODO: consider audio/visual feedback here
            return false;
        }
    }
}
