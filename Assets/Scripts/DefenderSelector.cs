using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class DefenderSelector : MonoBehaviour {

    public GameObject defenderToSpawn;
    public static DefenderSelector selectedDefender;
    private Text costText;
    private GameObject defendersParent;
    private SpriteRenderer spriteRenderer;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defendersParent = GameObject.Find("Defenders");
        costText = GetComponentInChildren<Text>();
        int cost = defenderToSpawn.GetComponent<Defender>().spawnCost;
        costText.text = cost.ToString();
        Unselect();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.U)){
            Unselect();
        }
	}

    void Unselect(){
        spriteRenderer.material.color = Color.black;
    }

    public void Selected(){
        if (selectedDefender){
            selectedDefender.Unselect();   
        }
        selectedDefender = this;

        spriteRenderer.material.color = Color.white;
    }

    private void TestSpawnSelected(){
        Instantiate(defenderToSpawn, new Vector2(Random.Range(0, 10), Random.Range(0, 6)), Quaternion.identity, defendersParent.transform);
    }

    private void OnMouseDown()
	{
        Selected();
	}
}
