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

		// when setting up a 2D object for this, you need to put this on an empty object
		// and then have a child object that is the actual image, rotated 90 on X axis
		
	}
}
