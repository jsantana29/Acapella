using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour {

    private Rigidbody rb;

    private Vector3 finalVelocity = Vector3.zero;
    private Vector3 finalRotation = Vector3.zero;
    private Vector3 finalCamRotation = Vector3.zero;

    [SerializeField]
    private Camera mainCam;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PerformMovement();
        PerformRotation();
	}

    //Takes in the velocity vector from PlayerController
    public void Move(Vector3 velocity)
    {
        finalVelocity = velocity;
    }

    //Takes in the rotation vector from PlayerMove
    public void Rotate(Vector3 rotation)
    {
        finalRotation = rotation;
    }

    public void camRotate(Vector3 camRotation)
    {
        finalCamRotation = camRotation;
    }

    //Actually performs the movement on the player
    void PerformMovement()
    {
        rb.MovePosition(rb.position + finalVelocity * Time.fixedDeltaTime);
    }

    //Actually performs the rotation on the player
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(finalRotation));

        if(mainCam != null)
        {
            mainCam.transform.Rotate(-finalCamRotation);
        }
    }

   
}
