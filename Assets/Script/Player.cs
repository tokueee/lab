using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    float mspeed = 3f;//�����x�ϐ�
    int SaveSpeed = 5;//���x����p�ϐ�
    public bool flag = false;
    public bool flag2 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }
    private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.name == "Button")
         {
             //Debug.Log("true");
             flag = true;
         }
         if (collision.gameObject.name == "Button2")
         {
             flag2 = true;
         }
     }

     private void OnCollisionExit(Collision collision)
     {
         if (collision.gameObject.name == "Button")
         {
             flag = false;
             Debug.Log(flag);
         }
         if(collision.gameObject.name == "Button2")
         {
             flag2 =false;
         }
     }


    // Update is called once per frame
    void FixedUpdate()
    {

        //���x�����o���Đ��䂷��if��
        if (rb.velocity.magnitude > SaveSpeed)
        {
            mspeed = -8;
        }
        else if (rb.velocity.magnitude < SaveSpeed && rb.velocity.magnitude > 0f)
        {
            mspeed += SaveSpeed;
        }
        else if (rb.velocity.magnitude <= 0f)
        {
            mspeed = SaveSpeed;
        }

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

        //Shift�L�[�Ń_�b�V������
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SaveSpeed = 5;
        }
        else
        {
            SaveSpeed = 3;
        }
    }
}
