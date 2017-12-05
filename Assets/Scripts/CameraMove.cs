using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public GameObject player;
	private Vector3 offsetX, offsetY;

	public float height = 8f;
	public float distance = 10f;
	public float TurnSpeed = 3f;
	// Use this for initialization
	void Start () {
		offsetX = new Vector3 (distance, height, 0 );
		offsetY = new Vector3 (0, height, 0 );
	}
		
	void LateUpdate () {
		offsetX = Quaternion.AngleAxis (Input.GetAxis ("CameraHorizontal") * TurnSpeed, Vector3.down) * offsetX;
		offsetY = Quaternion.AngleAxis (Input.GetAxis ("CameraVertical") * TurnSpeed, Vector3.right) * offsetY;

		transform.position = player.transform.position + offsetX;
		//transform.position = player.transform.position + offsetX;
		transform.LookAt (player.transform);
	}
}
