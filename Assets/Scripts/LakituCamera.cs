using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakituCamera : MonoBehaviour {

	float inputX;
	float inputZ;

	//the limits for the camera movement, can't go too far left, right, or whatever. if we want mario to have the
	//full 360 range of camera movement that's fine too. we can always edit these values
	int rightView = 50;
	int leftView = 310;
	int upView = 320;
	int downView = 40;

	Vector3 marioRotation;

	void Update () {
		//finds the rotation of the parent object of the camera 
		marioRotation = new Vector3 (
			transform.parent.eulerAngles.x, 
			transform.parent.eulerAngles.y, 
			transform.parent.eulerAngles.z); 

		inputX = Input.GetAxis ("CameraHorizontal");
		inputZ = Input.GetAxis ("CameraVertical");
	
		//if left or right arrow keys are being pressed OR a or d then start incrementing float inputX or Z
		//this can be made more specific later but i wasn't sure what controls we wanted to use
		if (inputX != 0) {
			rotateX ();
//			if (transform.eulerAngles.y >= rightView && transform.eulerAngles.y <= leftView - 5) {
//				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, rightView, transform.eulerAngles.z);
//			}
//			if (transform.eulerAngles.y <= leftView && transform.eulerAngles.y > rightView + 5) {
//				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, leftView, transform.eulerAngles.z);
//
//			}
		}
		if (inputZ != 0) {
			rotateZ ();
//			if (transform.eulerAngles.x >= downView && transform.eulerAngles.x <= upView - 5) {
//				transform.eulerAngles = new Vector3 (downView, transform.eulerAngles.y, transform.eulerAngles.z);
//			}
//			if (transform.eulerAngles.x <= upView && transform.eulerAngles.x > downView + 5) {
//				transform.eulerAngles = new Vector3 (upView, transform.eulerAngles.y, transform.eulerAngles.z);
//			}
		}

		//if no arrows are being pressed the camera will slowly pan back to its starting angle behind marios head
		if (inputX == 0 && inputZ == 0){
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (marioRotation), Time.deltaTime * 0.8f);
		}
	}

	//rotates the camera left and right
	void rotateX(){
		transform.Rotate (new Vector3 (0f, inputX * Time.deltaTime * 20f, 0f));
	}
	//rotates the camera up and down
	void rotateZ(){
		transform.Rotate (new Vector3 (-inputZ * Time.deltaTime *20f, 0f, 0f ));
	}
}
