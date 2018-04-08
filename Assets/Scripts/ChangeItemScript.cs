using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItemScript : MonoBehaviour {

    public Sprite[] sprites;
    public KeyCode keyCodeNextItem = KeyCode.N;
    public KeyCode keyCodeRandomize = KeyCode.R;

    private SpriteRenderer spriteRenderer;
    private int ix;

    void Start () {
        ix = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        
        if(Input.GetKeyDown(keyCodeNextItem)){
            NextItem();
        }
        if(Input.GetKeyDown(keyCodeRandomize)){
            RandomItem();
        }
	}
    void NextItem(){
        ix++;
        if (ix >= sprites.Length)
        {
            ix = 0;
        }
        spriteRenderer.sprite = sprites[ix];
    }
    void RandomItem(){
        spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];
    }
}

