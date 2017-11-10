using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MarioMovement : MonoBehaviour {
	public float speed = 6f;
	public float jumpSpeed = 8f;
	public float grav = 20f;
	Vector3 moveDir = Vector3.zero;
	Vector3 previousLoc;
	Vector3 currentLoc;
	void Update () {

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		//var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
		transform.Rotate(0, x, 0);
		previousLoc = currentLoc;
		currentLoc = transform.position;
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded)
		{
			moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDir = transform.TransformDirection(moveDir);
			moveDir *= speed;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				moveDir.y = jumpSpeed;
			}
		}
		moveDir.y -= grav * Time.deltaTime;
		controller.Move (moveDir * Time.deltaTime);
	}
}

//glitchy turning code. keeping just in case. originally from update
//  if (Vector3.Distance (previousLoc, currentLoc) > 0.05f)  {
//       if (Input.GetKey(KeyCode.S))
//      {
//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - previousLoc), Time.deltaTime);
//        transform.Rotate(0f, 360f * Time.deltaTime, 0f);
//    }
// }
