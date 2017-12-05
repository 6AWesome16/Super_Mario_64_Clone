using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobombView : MonoBehaviour {

	float WalkRotation;
	public float ViewRadius;
	[Range(0,360)]
	public float ViewAngle;

	public LayerMask marioMask;
	public LayerMask obstacleMask;

	public List<Transform> VisibleMario = new List<Transform>();
	bool isCoroutineRunning = false;

	void Start(){
		if (Random.Range (0, 100) >= 50) {
			WalkRotation = 20;
		} else {
			WalkRotation = -20;
		}
		StartCoroutine ("FindMarioWithDelay", 0f);
	}

	IEnumerator FindMarioWithDelay(float delay){
		while (true) {
			yield return new WaitForSeconds (delay);
			FindMario ();

		}
	}

	void FindMario(){
		VisibleMario.Clear ();
		isCoroutineRunning = false;
		Collider[] MarioInViewRadius = Physics.OverlapSphere (transform.position, ViewRadius, marioMask);

		for (int i = 0; i < MarioInViewRadius.Length; i++) {
			Transform mario = MarioInViewRadius [i].transform;
			Vector3 dirToMario = (mario.position - transform.position).normalized;
			if (Vector3.Angle (transform.forward, dirToMario) < ViewAngle / 2) {
				float distToMario = Vector3.Distance (transform.position, mario.position);

				if (!Physics.Raycast (transform.position, dirToMario, distToMario, obstacleMask)) {
					isCoroutineRunning = true;
					Debug.Log("is this ever happening");
					transform.LookAt (mario);
					transform.position = Vector3.MoveTowards (transform.position, mario.position, Time.deltaTime * 6);
					VisibleMario.Add (mario);
				}
			}
		}
	}

	void Update(){
		if (!isCoroutineRunning) {
			transform.position += transform.forward * Time.deltaTime * 6;
			transform.eulerAngles = new Vector3(
				transform.eulerAngles.x,
				(transform.eulerAngles.y + WalkRotation * Time.deltaTime), 
				0);
		}
	}
		
	public Vector3 DirFromAngle (float AngleDegrees, bool AngleIsGlobal){
		if (!AngleIsGlobal) {
			AngleDegrees += transform.eulerAngles.y;
		}
		return new Vector3 (Mathf.Sin (AngleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos (AngleDegrees * Mathf.Deg2Rad));
	}

}
