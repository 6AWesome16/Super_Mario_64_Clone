using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour {

	public float speed = 6f;
	public float jumpSpeed = 8f;
	public float grav = 20f;

	Vector3 moveDir = Vector3.zero;

	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;

	    transform.Rotate(0, x, 0);

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
