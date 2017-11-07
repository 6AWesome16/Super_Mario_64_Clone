using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	

	// at coin creation, send a ray down until it hits something, and then teleport the coin to the ground
	void Start () {

		Ray groundCheck = new Ray (transform.position, Vector3.down);
		float maxRayDistance = 6.0f;
		Debug.DrawRay (groundCheck.origin, groundCheck.direction * maxRayDistance, Color.yellow);
		RaycastHit groundFound = new RaycastHit ();

		if (Physics.Raycast (groundCheck, out groundFound, maxRayDistance)) {
			// teleport coin to the raycast hit point plus a certain height
			transform.position = groundFound.point + new Vector3 (0f, 0.6f, 0f);
		}


	}
}
