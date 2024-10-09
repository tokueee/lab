using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    float mspeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * mspeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * mspeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * mspeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * mspeed);
        }
    }
}
