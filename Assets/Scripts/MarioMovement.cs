using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Problems:
//I want to limit mario's velocity past a certain point
//mario's not great with hills
public class MarioMovement : MonoBehaviour
{
    public float distToGround = 2f;
    //forcePow is the speed mario can reach
    public float forcePow;
    public float jumpSpeed = 1f;
    public float turnSpeed;
    public float maxSpeed = 30f;
    Rigidbody rb;
    Vector3 inputVector;
    //public GameObject marioModel;

	public float jumpChainTimer = 0f;  // this increases when Mario lands from a jump and ticks down over time
									// it allows mario to do those cooool jumps

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    bool isGrounded()
    {
        //Debug.DrawRay(transform.position, Vector3.down * distToGround,Color.cyan);
        //return Physics.Raycast(transform.position, Vector3.down, distToGround);
        RaycastHit marioRayHit = new RaycastHit();
        //spherecast has origin point, radius, direction, out hit, max distance
        //these values specifically keep mario from getting stuck on corners
        //*please do not mess with them*
        return Physics.SphereCast(transform.position + new Vector3(0, 1f,0), 1f, Vector3.down, out marioRayHit,distToGround);
        //use this line of code to check for the seesaw
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
        if (isGrounded())
        {


			// unknown
            //if (inputV != 0f || rotate != 0f)
            //{
                //marioModel.transform.forward =  Vector3.Lerp(transform.forward, new Vector3(rb.velocity.x, 0, rb.velocity.z), Time.deltaTime * 5f);
            //}


			// tick down over time
			if (jumpChainTimer > 0f) {
				jumpChainTimer -= Time.deltaTime;
			}

			//changes y of inputVector to jump at rate of jumpSpeed
			if(Input.GetKeyDown(KeyCode.Space))
			{
				// jump chain timer less than a number, first jump happens
				if (jumpChainTimer <= 0.5f) {
					inputVector.y = jumpSpeed;
				} else if (jumpChainTimer > 0.5f) {
					inputVector.y = jumpSpeed * 2;
				}
			}

        }

        //if mario isn't grounded, set inputVector to 0, stops him from moving in midair
        if (!isGrounded())
        {
			inputVector = new Vector3(inputVector.x, 0, inputVector.z);
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
        
        //Debug.Log(inputVector*forcePow);
    }


	void OnCollisionEnter (Collision col){

		// if mario collides with the level, increase jump chain timer by a little bit
		// manually make seesaw count as ground, please! (in tags)
		// currently this triggers sometimes when mario is just walking
		if (col.collider.CompareTag ("Ground")) {
			jumpChainTimer += 2f;
		}


	}

}


