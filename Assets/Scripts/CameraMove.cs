using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public GameObject player;
	private Vector3 offsetX, offsetY;
	float LookAngleX;
	float LookAngleY;

	public float height;
	public float distance;
	public float TurnSpeed;
	// Use this for initialization
	void Start () {
//		offsetX = new Vector3 (0, 0, distance);
//		offsetY = new Vector3 (0, height/2, 0 );

	}
		
	void LateUpdate () {
//		offsetX = Quaternion.AngleAxis (Input.GetAxis ("CameraHorizontal") * TurnSpeed, Vector3.down) * offsetX;
//		offsetY = Quaternion.AngleAxis (Input.GetAxis ("CameraVertical") * TurnSpeed, Vector3.right) * offsetY;
//
//		transform.position = player.transform.position + offsetY;
//		transform.LookAt (player.transform);
	}

	void Update(){
		
		transform.RotateAround(player.transform.position, -player.transform.up, TurnSpeed * Input.GetAxis("CameraHorizontal"));
		transform.RotateAround(player.transform.position, player.transform.right, TurnSpeed * Input.GetAxis("CameraVertical"));
//		transform.position -= Vector3.up * -Input.GetAxis ("CameraVertical");
		transform.LookAt (player.transform);
		//LookAngleY = transform.eulerAngles.y;
		//LookAngleX = Mathf.Clamp(transform.eulerAngles.x + TurnSpeed * Input.GetAxis("CameraVertical"), -40, 70);
		//transform.eulerAngles = new Vector3 (LookAngleX, LookAngleY, 0);
//		float yLowerbound = player.transform.position.y;
//		Ray ray = new Ray(transform.position + Vector3.up * 5, Vector3.down);
//		RaycastHit hit;
//		if (Physics.Raycast (ray, out hit)) {
//			yLowerbound = hit.point.y + 1;
//		}
//		transform.position = new Vector3 (transform.position.x, Mathf.Clamp(transform.position.y, yLowerbound -2, player.transform.position.y + 6), transform.position.z);
//	}
	}
}
//Vector3.Cross(transform.position - new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), player.transform.up)
