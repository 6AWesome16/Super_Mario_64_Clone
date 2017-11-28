using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour {

	Rigidbody goombaRigidBody; // assigned in Start

	bool isWalkCoroutineRunning = false;
	bool isTurnCoroutineRunning = false;
	bool isAlertedCoroutineRunning = false;
	bool isDeathCoroutineRunning = false;
	bool isDashCoroutineRunning = false;

	public Transform mario; // set in inspector

	public bool marioSighted = false; // this toggles when the goombamariodiscover script notices mario

	public enum goombaState{
		walking,
		turning,
		alerted,
		dash,
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
			// always move forward if in walking state
			transform.Translate (Time.deltaTime, 0f, 0f);
			StartCoroutine (goombaWalkingCoroutine ());
		}
		if (myGoombaState == goombaState.turning) {
			StartCoroutine (goombaTurnCoroutine ());
		}
		if (myGoombaState == goombaState.alerted) {
			StartCoroutine (goombaAlertedCoroutine ());
		}
		if (myGoombaState == goombaState.dash) {
			StartCoroutine (goombaDashCoroutine ());
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

		// randomly check to jump every second
		yield return new WaitForSeconds (1f);
		if (Random.Range (0, 5) == 1) {
			myGoombaState = goombaState.turning;
		}

		// switch to alerted state if mario is seen! (from the goombamariodiscover script
		if (marioSighted == true) {
			// jump up
			goombaRigidBody.velocity += new Vector3 (0f, 15f, 0f);

			myGoombaState = goombaState.alerted;
			marioSighted = false;
			yield break;
		}

		isWalkCoroutineRunning = false;

	}

	IEnumerator goombaTurnCoroutine(){

		if (isTurnCoroutineRunning == true) {
			yield break;
		}

		isTurnCoroutineRunning = true;

		// rotate randomly over a little time
		float t = 0f;
		float randRotate = Random.Range (-180f, 180f);
		while (t < 0.5f) {
			t += Time.deltaTime;
			transform.Rotate (0f, randRotate * Time.deltaTime, 0f);
			transform.Translate (Time.deltaTime, 0f, 0f); // keep moving forward while turning
			yield return 0;
		}

		myGoombaState = goombaState.walking;

		yield return new WaitForSeconds (1f);

		isTurnCoroutineRunning = false;

	}

	IEnumerator goombaAlertedCoroutine(){
		if (isAlertedCoroutineRunning == true) {
			yield break;
		}

		isAlertedCoroutineRunning = true;

		// what should happen here is that the goomba should turn towards mario
		// and then stop after 0.5 seconds
		// and switch to dash state

		// instead it gets stuck and never stops turning towards mario
		float t = 0f;
		while (t < 0.5f) {
			Vector3 fromGoombaToMario = mario.position - transform.position; // figure out distance between
			Quaternion targetRotation = Quaternion.LookRotation (-fromGoombaToMario); // set target rotation
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * 4f); // rotate towards target
			yield return 0;
		}
		myGoombaState = goombaState.dash;

		yield return new WaitForSeconds (5f);

		isAlertedCoroutineRunning = false;

	}

	IEnumerator goombaDashCoroutine(){
		if (isDashCoroutineRunning == true) {
			yield break;
		}

		isDashCoroutineRunning = true;

		// move forward quickly and then switch to walk state
		float t = 0f;
		while (t < 2f) {
			t += Time.deltaTime;
			transform.Translate (4 * Time.deltaTime, 0f, 0f); // dash forward
			yield return 0;
		}
		yield return new WaitForSeconds (2f);

		myGoombaState = goombaState.walking;

		isDashCoroutineRunning = false;

	}

	IEnumerator goombaDeathCoroutine(){

		if (isDeathCoroutineRunning == true) {
			yield break;
		}

		isDeathCoroutineRunning = true;

		// flatten self when killed
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

		// placeholder if mario's feet hitbox hits the goomba then kill
		// obsolete now please make a way to kill goombas by triggering this

		if (collision.gameObject.name == "MarioFeetHitbox") {
			myGoombaState = goombaState.dying;
		}
	}


}
