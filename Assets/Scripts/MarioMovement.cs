using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour {
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float grav = 20f;

	public Transform Mario;

	Vector3 moveDir = Vector3.zero;
    Vector3 previousLoc;
    Vector3 currentLoc;
	
	void Update () {
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
		if (Vector3.Distance (previousLoc, currentLoc) > 0.05f) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLoc), Time.deltaTime * speed);
		}

        moveDir.y -= grav * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
	}
}
