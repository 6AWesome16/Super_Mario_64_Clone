using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakituCamera : MonoBehaviour {

	float inputX;
	float inputY;
	float LookAngleX;
	float LookAngleY;

	public GameObject player;
	Vector3 offset;
	Vector3 PlayerRotation;
	Quaternion rotationH, rotationV;
	float CameraAngle;

	void Start(){
		offset = player.transform.position - transform.position;
		CameraAngle = player.transform.eulerAngles.y;
		rotationH = Quaternion.Euler (0, CameraAngle, 0);
		rotationV = Quaternion.Euler (CameraAngle, 0, 0);
		LookAngleX = transform.eulerAngles.y;
		LookAngleY = transform.eulerAngles.x;
	}

	void Update () {
		
		//finds the rotation of the parent object of the camera 
		PlayerRotation = new Vector3 (
			player.transform.eulerAngles.x, 
			player.transform.eulerAngles.y, 
			player.transform.eulerAngles.z); 

		inputX = Input.GetAxis ("CameraHorizontal");
		inputY = Input.GetAxis ("CameraVertical");
	
		//if left or right arrow keys are being pressed then start rotating X or Y
		if (inputX != 0) {
			rotateX ();
			transform.position = player.transform.position - (rotationH * offset);
		}
		if (inputY != 0) {
			

		}

		//if no arrows are being pressed the camera will pan back to its starting angle behind marios head
		if (inputX == 0 && inputY == 0) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (PlayerRotation), Time.deltaTime * 0.8f);
		} else {
			//locks the Z position of the camera
			transform.eulerAngles = new Vector3 (
				LookAngleY,
				LookAngleX,
				0);
		}
	}

	void LateUpdate(){
		transform.LookAt (player.transform);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);
	}

	//rotates the camera left and right
	void rotateX(){
		//transform.Rotate (new Vector3 (0f, inputX * Time.deltaTime * 30f, 0f));
		LookAngleX += inputX * Time.deltaTime *20f;
	}
	//rotates the camera up and down
	void rotateY(){
		//transform.Rotate (new Vector3 (-inputY * Time.deltaTime *20f, 0f, 0f ));
//		LookAngleY -= inputY * Time.deltaTime * 20f;
//		LookAngleY = Mathf.Clamp (LookAngleY, -85, 85);

		Debug.Log ("just checking");
	}
}
