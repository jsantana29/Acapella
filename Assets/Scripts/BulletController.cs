using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    
    private Material material;
    private Rigidbody2D rb;
    private Vector3 bulletVelocity;


    [SerializeField]
    private int bulletSpeed = 5;

	// Use this for initialization
	void Start () {
        //material.color = Color.red;
        
	}
	
	// Update is called once per frame
	void Update () {
        //rb.velocity = transform.forward * 6;
	}

    //private void OnCollisionEnter(Collider collision)
    //{
    //    if(collision.name == "Enemy")
    //    {
    //        collision.GetComponent<AudioSource>().Play();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Trigger noticed");
            other.GetComponent<AudioSource>().Play();
        }
    }
}
