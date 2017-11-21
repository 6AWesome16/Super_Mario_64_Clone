using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Problems:
//marios force gets added to his jump, if he doesn't have momentum he can't jump anywhere
//I want to limit mario's velocity past a certain point
public class MarioMovement : MonoBehaviour
{
    public float distToGround = 2f;
    //forcePow is the speed mario can reach
    public float forcePow;
    public float jumpSpeed = 8f;
    public float turnSpeed;
    Rigidbody rb;
    Vector3 inputVector;
    

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
    }

    void Update()
    {
        Debug.Log(isGrounded());
        if (isGrounded())
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

            //changes y of inputVector to jump at rate of jumpSpeed
            if (Input.GetKey(KeyCode.Space))
            {
                inputVector.y = jumpSpeed;
            }
        }
        //if mario isn't grounded, set inputVector to 0, stops him from moving in midair
        //glitchy on corners, mario can get stuck
        if (!isGrounded())
        {
            inputVector = new Vector3(0, 0, 0);
        }
    }
    void FixedUpdate()
    {
        //should move mario forward at the rate of forcePow
        //adds force to forward, but I want it to add force for wherever he is facing
        //rb.AddForce(transform.TransformDirection(inputVector) * forcePow);
        //this is where the jump problem occurs. it multiplies the jumpspeed by forcepow when jumping
        //rb.AddRelativeForce(inputVector * forcePow);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(inputVector * forcePow);
        }
        else if(!Input.GetKey(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddRelativeForce(inputVector * forcePow);
        }
        Debug.Log(inputVector*forcePow);
    }
}


