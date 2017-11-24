using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMarioDiscover : MonoBehaviour {

	public Transform mario; // set in inspector please


	void OnTriggerEnter(Collider collision){

		// if i touch mario, my goomba parent sees him

		if (collision.transform == mario) {
			transform.parent.GetComponent<GoombaMovement> ().marioSighted = true;
		}

	}

}
