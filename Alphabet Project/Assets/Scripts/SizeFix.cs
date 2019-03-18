using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeFix : MonoBehaviour {

    private SpriteRenderer spriteRend;

	// Use this for initialization
	void Start () {
        spriteRend = GetComponent<SpriteRenderer>();
        float heightScreen = Camera.main.orthographicSize * 2f;
        float widthScreen = heightScreen * Screen.width / Screen.height;
        float heightObject = heightScreen / spriteRend.sprite.bounds.size.y;
        float widthObject = widthScreen / spriteRend.sprite.bounds.size.x;
        //transform.localScale = new Vector3(widthObject, heightObject, 1f);
        Debug.Log(widthObject);
	}
}
