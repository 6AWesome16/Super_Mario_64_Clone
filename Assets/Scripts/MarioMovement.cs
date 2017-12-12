using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Problems:
//I want to limit mario's velocity past a certain point
//mario's not great with hills
public class MarioMovement : MonoBehaviour
{
    //public float distToGround = 2f;
    //forcePow is the speed mario can reach
    public float forcePow;
    public float jumpSpeed = 40f;
    public float turnSpeed;
    public float maxSpeed = 30f;
    Rigidbody rb;
    Vector3 inputVector;

    Animator myAnimator;

	public float jumpChainTimer = 0f;  // this increases when Mario lands from a jump and ticks down over time
									// it allows mario to do those cooool jumps

	public float midAirTimer = 0f; // increases when mario is in air, for jump stuff

	public bool grounded = false; // ground raycast check


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

		//inputV goes between 0 and 1, goes up when held down, goes down when lifted
		float inputV = Input.GetAxis("Vertical");
		//rotate goes between 0 and 1 multiplied by time.deltatime. multiplying by turnspeed increases turning speed
		float rotate = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;


		//should rotate mario at rate of rotate
		transform.Rotate(0, rotate, 0);

		//inputVector takes inputV
		inputVector = new Vector3(0f, 0f, inputV);

		//normalizes inputVector, avoids diagonal movement exploit
		if (inputVector.magnitude > 1f)
		{
			inputVector = Vector3.Normalize(inputVector);
		}

		inputVector *= forcePow;

        //Debug.Log(isGrounded());
		if (grounded == true)
        {
            myAnimator.SetBool("isJumping", false);
            //if arrow keys pressed set running to true
            if (Input.GetAxis("Vertical") != 0)
            {
                myAnimator.SetBool("isRunning", true);
            }
            else
            {
                myAnimator.SetBool("isRunning", false);
            }
			// tick down over time
			if (jumpChainTimer > 0f) {
				jumpChainTimer -= Time.deltaTime;
			}
			if (jumpChainTimer >= 1f) {
				jumpChainTimer = 1f;
			}

			//changes y of inputVector to jump at rate of jumpSpeed
			if(Input.GetKeyDown(KeyCode.Space))
			{
                //causes animation to run, but finish midair as transitions back to idle
                //myAnimator.SetBool("isJumping", true);


                float xSpeed = rb.velocity.x;
				float zSpeed = rb.velocity.z;
				// jump chain timer less than a number, first jump happens
				if (jumpChainTimer <= 0.3f) {
					//inputVector.y = jumpSpeed;

					transform.GetComponent<Rigidbody>().velocity = new Vector3 (xSpeed, jumpSpeed, zSpeed);

				} else if (jumpChainTimer > 0.3f) {
					//inputVector.y = jumpSpeed * 1.5f;
					transform.GetComponent<Rigidbody>().velocity = new Vector3 (xSpeed, jumpSpeed * 1.6f, zSpeed);

					jumpChainTimer = 0f;
				}
			}

        }
        //if mario isn't grounded, set inputVector to 0, stops him from moving in midair
		else if (grounded == false)
        {
            //set jumping animation to true
            //makes jump animation last for whole jump, but if standing still
            //causes jump animation to reactivate for an instant on landing
            //myAnimator.SetBool("isJumping", true);

            inputVector = new Vector3(inputVector.x, 0, inputVector.z);

			midAirTimer += Time.deltaTime;
            myAnimator.SetBool("isJumping", true);

        }



        // ray for groundcast
        Ray groundedRay = new Ray(transform.position, Vector3.down);
		float maxRayDistance = 2f;
		Debug.DrawRay (groundedRay.origin, groundedRay.direction * maxRayDistance, Color.yellow);
		RaycastHit groundRayHit = new RaycastHit ();

		if (Physics.Raycast (groundedRay, maxRayDistance)) {
			grounded = true;

        }
        else {
			grounded = false;
		}

		if (Physics.Raycast (groundedRay, out groundRayHit)) {
			if (groundRayHit.collider.CompareTag ("Goomba")) {
				groundRayHit.collider.GetComponent<GoombaMovement> ().goombaDeath ();
			}
		}



    }
    void FixedUpdate()
    {
        //should move mario forward at the rate of forcePow
        //adds force to forward, but I want it to add force for wherever he is facing
        rb.AddForce(transform.TransformDirection(inputVector));
        if(rb.velocity.magnitude > maxSpeed)
        {
            float ySpeed = rb.velocity.y;
            rb.velocity = rb.velocity.normalized* maxSpeed;
            rb.velocity = new Vector3(rb.velocity.x, ySpeed, rb.velocity.z);
        }

		if (grounded == true) {
			// check if no directional buttons are pressed
			if (inputVector == new Vector3 (0f, 0f, 0f)) {
				float ySpeed = rb.velocity.y;
				rb.velocity -= new Vector3 (rb.velocity.x / 1.1f, 0f, rb.velocity.z / 1.1f);
			}
		}

    }


	void OnCollisionEnter (Collision col){

		// if mario collides with the level, increase jump chain timer by a little bit
		// manually make seesaw count as ground, please! (in tags)
		// currently this triggers sometimes when mario is just walking
		if (col.collider.CompareTag ("Ground")) {
			if (midAirTimer >= 0.5f && midAirTimer <= 1.2f) {
					jumpChainTimer += 0.8f;
			}
			midAirTimer = 0f;
		}


	}

}


