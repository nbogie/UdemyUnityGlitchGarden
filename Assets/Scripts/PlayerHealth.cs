using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Text text;
    private int hitPoints;
    private LevelManager levelManager;
    public int maxHitPoints = 40;
    public Text lossText;

    void Start()
    {
        hitPoints = maxHitPoints;
        levelManager = FindObjectOfType<LevelManager>();
        text = GetComponent<Text>();
        UpdateText();
        lossText.enabled = false;

    }
    void UpdateText()
    {
        text.text = "Health: " + hitPoints.ToString();
    }
    public int GetHitPoints()
    {
        return hitPoints;
    }

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;
        UpdateText();
        if (hitPoints <= 0)
        {
            lossText.enabled = true;
            Invoke("Die", 2);
        }
    }

    void Die()
    {
        //TODO: fade out a couple of seconds before switching screen
        levelManager.LoadLoseScene();
    }

}
