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
    void FixedUpdate()
    {
        //�ړ�
        //�O�ɐi��
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * mspeed);
        }
        //��ɐi��
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * mspeed);
        }
        //�E�ɐi��
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * mspeed);
        }
        //���ɐi��
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * mspeed);
        }
    }

    private void Update() 
    {
        //key�𗣂����Ƃ��Ɏ~�܂�
        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.D)) 
        {
            if (Input.GetKey(KeyCode.W)||
                Input.GetKey(KeyCode.A)||
                Input.GetKey(KeyCode.S)||
                Input.GetKey(KeyCode.D))
            {
                
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
