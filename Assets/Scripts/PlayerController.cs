using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 5;    //brackevs source vid
    private float lookSensitivity = 3f;

    private PlayerMove motor;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject bullet;
    //Input.GetButton("Horizontal"); ARTIFACT

	// Use this for initialization
	void Start () {
        motor = GetComponent<PlayerMove>();
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
        motor.Move(velocity);

        //Calculate rotation as a 3D vector
        float yRotation = Input.GetAxisRaw("Mouse X");
        float xRotation = Input.GetAxisRaw("Mouse Y");
        
        //Sets horizontal rotation with a look sensitivity
        Vector3 rotation = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        Vector3 camRotation = new Vector3(xRotation, 0f, 0f) * lookSensitivity;

        //Applies rotation
        motor.Rotate(rotation);
        motor.camRotate(camRotation);

        if (Input.GetButton("Fire1"))
        {
            Instantiate(bullet, firePoint.position, Quaternion.Euler(rotation));
        }
    }
}
