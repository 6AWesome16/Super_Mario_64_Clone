using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCameraLock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		transform.forward = Camera.main.transform.forward;
		// the forward of the object is set to the forward of the camera every frame
		
	}
}
