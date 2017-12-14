using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobombView : MonoBehaviour {

	float WalkRotation;
	float yPos;
	public float ViewRadius;
	[Range(0,360)]
	public float ViewAngle;

	public LayerMask marioMask;
	public LayerMask obstacleMask;

	public List<Transform> VisibleMario = new List<Transform>();
	bool isChasingMario = false;

	void Start(){
		yPos = transform.position.y;
		if (Random.Range (0, 100) >= 50) {
			WalkRotation = 1;
		} else {
			WalkRotation = -1;
		}
	}

	void FindMario(){
		VisibleMario.Clear ();
		isChasingMario = false;
		Collider[] MarioInViewRadius = Physics.OverlapSphere (transform.position, ViewRadius, marioMask);

		for (int i = 0; i < MarioInViewRadius.Length; i++) {
			Transform mario = MarioInViewRadius [i].transform;
			Vector3 dirToMario = (mario.position - transform.position).normalized;
			if (Vector3.Angle (transform.forward, dirToMario) < ViewAngle / 2) {
				float distToMario = Vector3.Distance (transform.position, mario.position);

				if (!Physics.Raycast (transform.position, dirToMario, distToMario, obstacleMask)) {
					isChasingMario = true;
					Debug.Log("is this ever happening");


					transform.LookAt (mario);
					transform.GetComponent<Rigidbody> ().velocity = 
						(mario.transform.position - transform.position).normalized * Time.deltaTime * 600;
//					transform.position = Vector3.MoveTowards (new Vector3(
//						transform.position.x, yPos, transform.position.z), 
//						mario.position, Time.deltaTime * 6);
					VisibleMario.Add (mario);
				}
			}
		}
	}

	void walkInCircle(){
		transform.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		transform.Translate (Vector3.forward * Time.deltaTime * 6);
		//transform.rotation = Quaternion.LookRotation (-Vector3.forward);
		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x,
			(transform.eulerAngles.y + WalkRotation ), 
			0);
	}

	void Update() {
		FindMario (); // will set isChasingMario to true or false

		if (!isChasingMario) {
			walkInCircle ();
		}
	}

	public Vector3 DirFromAngle (float AngleDegrees, bool AngleIsGlobal){
		if (!AngleIsGlobal) {
			AngleDegrees += transform.eulerAngles.y;
		}
		return new Vector3 (Mathf.Sin (AngleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos (AngleDegrees * Mathf.Deg2Rad));
	}

}
