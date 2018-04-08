using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DefenderSpawner : MonoBehaviour
{
    private Transform defendersParent;
    private Camera myCamera;
    private StarCounter starCounter;
    private AudioSource audioSource;
    public AudioClip spawnOKClip;
    public AudioClip noMoneyToSpawnClip;

    void Start()
    {
        myCamera = Camera.main;
        defendersParent = GameObject.Find("Defenders").transform;
        starCounter = FindObjectOfType<StarCounter>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = WorldPositionOfMouseClick(Input.mousePosition);
        Vector2 gridPos = NearestGridSpace(worldPos);
        TryToSpawnAt(gridPos);
    }

    Vector2 WorldPositionOfMouseClick(Vector2 mousePos)
    {
        return myCamera.ScreenToWorldPoint(mousePos);
    }

    Vector2 NearestGridSpace(Vector2 worldPos)
    {
        return new Vector2(Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));
    }
    bool IsOkGridSpace(Vector2 gridPos){
        return (gridPos.x >= 1 && gridPos.x <= 9 && gridPos.y >= 1 && gridPos.y <= 5);
    }

    //could fail due to cost or illegal grid pos
    void TryToSpawnAt(Vector2 gridPos)
    {
        if (!IsOkGridSpace(gridPos))
        {
            return;
        }

        DefenderSelector selected = DefenderSelector.selectedDefender;
        if (selected)
        {
            Defender def = selected.defenderToSpawn.GetComponent<Defender>();
            if (starCounter.TryToUseStars(def.spawnCost))
            {
                Instantiate(def.gameObject, gridPos, Quaternion.identity, defendersParent);
                audioSource.clip = spawnOKClip;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = noMoneyToSpawnClip;
                audioSource.Play();
            }
        }
    }
}
