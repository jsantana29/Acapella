using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 finalVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PerformUpdate();
	}

    public void Move(Vector3 velocity)
    {
        finalVelocity = velocity;
    }

    void PerformUpdate()
    {
        rb.MovePosition(rb.position + finalVelocity * Time.fixedDeltaTime);
    }
}
