using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour {

	Vector3 firstMove;
	Vector3 secondMove;
	Vector3 thirdMove;
	Vector3 fourthMove;

	public Transform firstStop;
	public Transform secondStop;
	public Transform thirdStop;
	public Transform fourthStop;
	bool firstMoveHappened = false;
	bool secondMoveHappened = false;
	bool thirdMoveHappened = false;
	public Transform parentCube;
	float rotationsPerMinute = 30.0f;
	public float speed = 3.0f;
	private float startTime;
	private float journeyLength;

	void Awake(){
		firstMove = new Vector3(parentCube.position.x + 15,
			parentCube.position.y + 30,
			parentCube.position.z);

		secondMove = new Vector3 (firstMove.x, firstMove.y - 20, firstMove.z);
		thirdMove = new Vector3 (secondMove.x + 10, secondMove.y + 25, secondMove.z);
		fourthMove = new Vector3 (thirdMove.x + 5, thirdMove.y - 10, thirdMove.z);
	}
	void Start(){
		startTime = Time.time;
		journeyLength = Vector3.Distance (parentCube.position, firstMove);
	}

	void Update () {
		parentCube.Rotate(0,-10f * rotationsPerMinute*Time.deltaTime, 0);

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		if ((Vector3.Distance (parentCube.position, firstStop.position) >= 1) && firstMoveHappened == false) {
			parentCube.position = Vector3.Lerp (parentCube.position, firstStop.position, fracJourney);
		//	Debug.Log ("god this is annoying");
		} else if (Vector3.Distance (parentCube.position, firstStop.position) <= 2) {
			firstMoveHappened = true;
		}
		if (firstMoveHappened && secondMoveHappened == false) {
			parentCube.position = Vector3.Lerp (parentCube.position, secondStop.position, fracJourney *0.4f);
			//Debug.Log ("asdlkfjsa");
		} if (Vector3.Distance (parentCube.position, secondStop.position) <= 2) {
			secondMoveHappened = true;
		} if (secondMoveHappened && thirdMoveHappened == false) {
			parentCube.position = Vector3.Lerp (parentCube.position, thirdStop.position, fracJourney *0.4f);
			//Debug.Log ("heyyyyy its the third one");
		} if (Vector3.Distance (parentCube.position, thirdStop.position) <= 2) {
			thirdMoveHappened = true;
		} if (thirdMoveHappened) {
			parentCube.position = Vector3.Lerp (parentCube.position, fourthStop.position, fracJourney * 0.4f);
			//Debug.Log ("fourth");
		}
//		if (((parentCube.position.x <= firstMove.x - 1) || (parentCube.position.y <= firstMove.y - 1)) && firstMoveHappened == false) {
//			Debug.Log ("first part here");
//		} else if ((parentCube.position.x >= firstMove.x - 1) || (parentCube.position.y >= firstMove.y - 1)) {
//			firstMoveHappened = true;
//			parentCube.position = Vector3.Lerp (parentCube.position, secondMove, fracJourney);
//			Debug.Log ("second part here");
//		} else if ((parentCube.position.x <= secondMove.x - 5) || (parentCube.position.y <= secondMove.y - 5)) {
//			parentCube.position = Vector3.Lerp (parentCube.position, thirdMove, fracJourney);
//			Debug.Log ("third part here");
//		} else if ((parentCube.position.x >= secondMove.x - 1) || (parentCube.position.y >= secondMove.y - 1)) {
//			parentCube.position = Vector3.Lerp (parentCube.position, fourthMove, fracJourney);
//			Debug.Log ("fourth part here");
//		}
//
	}
}
