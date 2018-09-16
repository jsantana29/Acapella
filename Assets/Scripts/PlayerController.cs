using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5; 
    //brackevs source vid
    private float lookSensitivity = 3f;
    float nextFire = 0.0f;
    public float firerate = 0.5f;
    public int bulletSpeed = 5;
    public float jumpHeight = 10f;



    private PlayerMove motor;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject AR;

    [SerializeField]
    private Camera camera;
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
        motor.move(velocity);

        //Calculate rotation as a 3D vector
        float yRotation = Input.GetAxisRaw("Mouse X");
        float xRotation = Input.GetAxisRaw("Mouse Y");
        
        //Sets horizontal rotation with a look sensitivity
        Vector3 rotation = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        Vector3 camRotation = new Vector3(xRotation, 0f, 0f) * lookSensitivity;

        //Applies rotation
        motor.rotate(rotation);
        motor.camRotate(camRotation);

        //AR.transform.Rotate(-camRotation);


        //Checks for input from left mouse button
        //Shoots based on fire rate
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            shootBullet(rotation);
        }

        if (Input.GetButton("Jump"))
        {
            Vector3 jumpVelocity = new Vector3(0f, jumpHeight, 0f);
            motor.playerJump(jumpVelocity);
        }
    }

    //Actually shoots bullet
    void shootBullet(Vector3 rotation)
    {
        var firedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        firedBullet.GetComponent<Rigidbody>().velocity = (firedBullet.transform.forward + camera.transform.forward) * bulletSpeed;
        nextFire = Time.time + firerate;

        Destroy(firedBullet, 2f);
    }

    
}
