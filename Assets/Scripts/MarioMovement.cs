using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public float distToGround = 1f;
    public float forcePow;
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float grav = 20f;
    public float turnSpeed;
    Rigidbody rb;
    Vector3 inputVector;
    //Vector3 moveDir = Vector3.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    bool isGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * distToGround,Color.cyan);
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }

    void Update()
    {
        Debug.Log(isGrounded());
        if (isGrounded())
        {
            //float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            float rotate = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
            //should rotate mario
            transform.Rotate(0, rotate, 0);

            inputVector = new Vector3(0f, 0f, inputV);

            if (inputVector.magnitude > 1f)
            {
                inputVector = Vector3.Normalize(inputVector);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                inputVector.y = jumpSpeed;
            }
        }
        if (!isGrounded())
        {
            inputVector = new Vector3(0, 0, 0);
        }
    }
    void FixedUpdate()
    {
        //should move mario forward
        rb.AddForce(transform.TransformDirection(inputVector) * forcePow);
    }
}
    //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;

    //transform.Rotate(0, x, 0);

    //CharacterController controller = GetComponent<CharacterController>();
    //if (controller.isGrounded)
    //{
    //   moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    //movedir is being influenced by the x on the joystick and the x that is rotating him

    //    moveDir = transform.TransformDirection(moveDir);
    //    moveDir *= speed;
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        moveDir.y = jumpSpeed;                
    //    }
    //}
    //moveDir.y -= grav * Time.deltaTime;
    //controller.Move (moveDir * Time.deltaTime);


