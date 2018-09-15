using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 5;    //brackevs source vid
    //private PlayerMotor motor;
    //Input.GetButton("Horizontal"); ARTIFACT

	// Use this for initialization
	void Start () {
        //motor = GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
        //return a percentage of how hard you are pushing a stick
        float xMovment = Input.GetAxisRaw("Horizontal");
        float yMovment = Input.GetAxisRaw("Vertical");

        //make a velocity vector that "pushes" the character
        Vector3 moveSide = transform.right * xMovment;
        Vector3 moveFront = transform.forward * yMovment;

        //the speed of the character
        Vector3 velocity = (moveSide + moveFront).normalized * speed;

        //move 
        ////motor.Move(velocity);
    }
}
