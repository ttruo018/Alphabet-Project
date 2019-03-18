using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionFix : MonoBehaviour {

    public float horizontalRes = 1920;

	// Use this for initialization
	void Start () {
        float currentAspect = (float) Screen.width / (float) Screen.height;
        //Camera.main.orthographicSize = horizontalRes / currentAspect / 2;
	}
	
}
