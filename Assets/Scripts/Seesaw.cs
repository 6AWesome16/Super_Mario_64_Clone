using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour {
    Rigidbody ss;
    Vector3 seesawReturn = new Vector3(0,0,500);
	// Use this for initialization
	void Start () {
        ss = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        Vector3 seesaw = transform.position + transform.right;
        if(seesaw.y < transform.position.y)
        {
            ss.AddTorque(seesawReturn);
        }
        else
        {
            ss.AddTorque(-seesawReturn);
        }        
    }
}
