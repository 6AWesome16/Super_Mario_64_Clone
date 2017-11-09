using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour {
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float grav = 20f;

	public Transform Mario; // TODO: this is unused?

	// TODO: when you have a series of var declarations that are all the same thing, you can do it all in one line
	// TODO: e.g. "Vector3 moveDir, previousLoc, currentLoc;"
	Vector3 moveDir = Vector3.zero;
    Vector3 previousLoc;
    Vector3 currentLoc;
	
	void Update () {
		// TODO: write comments!!! why are you doing this? what is it? etc
        previousLoc = currentLoc;
        currentLoc = transform.position;
		
		// TODO: write a comment about what this chunk of code is doing
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
		// TODO: what is this chunk of code doing? why?
		if (Vector3.Distance (previousLoc, currentLoc) > 0.05f) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLoc), Time.deltaTime * speed);
		}

        moveDir.y -= grav * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
	}
}
