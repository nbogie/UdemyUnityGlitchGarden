using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour {
    Image image;
    Color currentColor = Color.black;

	public void Start()
	{
        image = GetComponent<Image>();
        FadeMe();
	}

	public void FadeMe(){
        StartCoroutine(DoFade());        
    }

    IEnumerator DoFade(){
        
        while(image.color.a > 0){
            currentColor.a -= Time.deltaTime / 2f;
            image.color = currentColor;
            yield return null;
        }
        image.enabled = false;
        yield return null;
    }
}
