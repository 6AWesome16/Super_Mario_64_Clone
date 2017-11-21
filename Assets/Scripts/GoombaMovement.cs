using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour {

	Rigidbody goombaRigidBody; // assigned in Start

	bool isWalkCoroutineRunning = false;
	bool isJumpCoroutineRunning = false;
	bool isDeathCoroutineRunning = false;

	public enum goombaState{
		walking,
		jumping,
		dying
	}

	public goombaState myGoombaState = goombaState.walking;

	// Use this for initialization
	void Start () {

		goombaRigidBody = GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (myGoombaState == goombaState.walking) {
			transform.Translate (Time.deltaTime, 0f, 0f);
			StartCoroutine (goombaWalkingCoroutine ());
		}
		if (myGoombaState == goombaState.jumping) {
			StartCoroutine (goombaJumpCoroutine ());
		}
		if (myGoombaState == goombaState.dying) {
			StartCoroutine (goombaDeathCoroutine ());
		}

	}

	IEnumerator goombaWalkingCoroutine(){

		if (isWalkCoroutineRunning == true) {
			yield break;
		}

		isWalkCoroutineRunning = true;

		yield return new WaitForSeconds (1f);
		if (Random.Range (0, 5) == 1) {
			myGoombaState = goombaState.jumping;
		}

		isWalkCoroutineRunning = false;

	}

	IEnumerator goombaJumpCoroutine(){

		if (isJumpCoroutineRunning == true) {
			yield break;
		}

		isJumpCoroutineRunning = true;

		goombaRigidBody.velocity += new Vector3 (0f, 10f, 0f);
		yield return new WaitForSeconds (0.1f);
		float t = 0f;
		float randRotate = Random.Range (-180f, 180f);
		while (t < 0.5f) {
			t += Time.deltaTime;
			transform.Rotate (0f, randRotate * Time.deltaTime, 0f);
			yield return 0;
		}

		myGoombaState = goombaState.walking;

		yield return new WaitForSeconds (1f);

		isJumpCoroutineRunning = false;

	}

	IEnumerator goombaDeathCoroutine(){

		if (isDeathCoroutineRunning == true) {
			yield break;
		}

		isDeathCoroutineRunning = true;

		float t = 0f;
		while (t < 0.5f) {
			t += Time.deltaTime;
			transform.localScale -= new Vector3 (0f, 0.05f, 0f);
			yield return 0;
		}
		yield return new WaitForSeconds (0.6f);
		Destroy (gameObject);
			
	}


	void OnTriggerEnter(Collider collision) {

		if (collision.gameObject.name == "MarioFeetHitbox") {
			myGoombaState = goombaState.dying;
		}

	}


}
