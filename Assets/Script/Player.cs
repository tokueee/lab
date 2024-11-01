using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    CameraControll CameraCS;
    Vector3 get_see;

    [System.NonSerialized]//public変数をインスペクター上に表示したくない時に使えるやつ
    public int keyCount;
    [System.NonSerialized]
    public bool key_W, key_A, key_S, key_D, key_Shift;
    float[] global_x = new float[4], global_y = new float[4], global_z = new float[4];//移動制御変数
    Vector3 global;

    float mspeed;//速度変数
    public float Speed_Walking, Speed_Running;
    //※int SaveSpeed = 5;//速度制御用変数
    /*public bool flag = false;
    public bool flag2 = false;*/
    public bool[] flags;
    //flags[0] はbuttonの判定
    public GameObject[] Button;


    //ライト用↓
    [SerializeField]
    private GameObject Light;
    private Light player_light;
    private bool isON = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;// リジッドボディに重力を適用
        player_light = Light.GetComponent<Light>();
        UpdateLight();
        CameraCS = GetComponent<CameraControll>();

        key_Shift = true;
    }
    private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject == Button[0])
         {
            //Debug.Log("true");
            flags[0] = true;
         }
         if (collision.gameObject == Button[1])//名前変更に注意
         {
            flags[1] = false;
         }
     }

     private void OnCollisionExit(Collision collision)
     {
         if (collision.gameObject.name == "Button")
         {
            flags[0] = false;
            Debug.Log(flags[0]);
         }
         if(collision.gameObject.name == "Button2")
         {
            flags[1] =false;
         }
     }


    // Update is called once per frame
    void FixedUpdate()
    {
        get_see = CameraCS.Rot_Camera;
        //各速度の値を毎度初期化
        keyCount = 0;
        key_W = false; key_A = false; key_S = false; key_D = false;
        for (int i = 0; i < 4; i++)
        {
            global_x[i] = 0; global_y[i] = 0; global_z[i] = 0;
        }

        //※速度を検出して制御するif文
        {/*
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
            }*/
        }

        //移動
        {
            //前に進む
            if (Input.GetKey(KeyCode.W))
            {
                keyCount += 1;
                key_W = true;
                //rb.AddForce(transform.forward * mspeed);
                //global_z[1] = mspeed * Mathf.Cos(get_sea.y/180*Mathf.PI);
                //global_x[1] = mspeed * Mathf.Sin(get_sea.y / 180 * Mathf.PI);
            }
            //後に進む
            if (Input.GetKey(KeyCode.S))
            {
                keyCount += 1;
                key_S = true;
                //rb.AddForce(-transform.forward * mspeed);
                //global_z[3] = -mspeed * Mathf.Cos(get_sea.y / 180 * Mathf.PI);
                //global_x[3] = -mspeed * Mathf.Sin(get_sea.y / 180 * Mathf.PI);
            }
            //右に進む
            if (Input.GetKey(KeyCode.D))
            {
                keyCount += 1;
                key_D = true;
                //rb.AddForce(transform.right * mspeed);
                //global_z[4] = mspeed * Mathf.Cos((get_sea.y+90) / 180 * Mathf.PI);
                //global_x[4] = mspeed * Mathf.Sin((get_sea.y+90) / 180 * Mathf.PI);
            }
            //左に進む
            if (Input.GetKey(KeyCode.A))
            {
                keyCount += 1;
                key_A = true;
                //rb.AddForce(-transform.right * mspeed);
                //global_z[2] = -mspeed * Mathf.Cos((get_sea.y + 90) / 180 * Mathf.PI);
                //global_x[2] = -mspeed * Mathf.Sin((get_sea.y + 90) / 180 * Mathf.PI);
            }
        }

        //左Shiftキーを検知する
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //SaveSpeed = 5;
                key_Shift = true;
            }
            else
            {
                //SaveSpeed = 3;
                key_Shift = false;
            }

            if (keyCount >= 2)
            {
                mspeed = mspeed / Mathf.Sqrt(2);
                //Debug.Log(Mathf.Sqrt(2));

            }
        }

    }

    private void Update() 
    {
        Debug.Log(isON);
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChageLight();
        }
        //※keyを離したときに止まる
        {/*
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
            }*/
        }

        //Shiftキーでダッシュする
        {
            if (key_Shift)
            {
                //SaveSpeed = 5;
                mspeed = Speed_Running;
            }
            else
            {
                //SaveSpeed = 3;
                mspeed = Speed_Walking;
            }

            if (keyCount >= 2)
            {
                mspeed = mspeed / Mathf.Sqrt(2);
                //Debug.Log(Mathf.Sqrt(2));

            }
        }
        //WASD keyのどれかが押されたときの反応(移動)
        {
            if (key_W)
            {
                //rb.AddForce(transform.forward * mspeed);
                global_z[0] = mspeed * Mathf.Cos(get_see.y / 180 * Mathf.PI);
                global_x[0] = mspeed * Mathf.Sin(get_see.y / 180 * Mathf.PI);
            }
            //後に進む
            if (key_S)
            {
                //rb.AddForce(-transform.forward * mspeed);
                global_z[2] = -mspeed * Mathf.Cos(get_see.y / 180 * Mathf.PI);
                global_x[2] = -mspeed * Mathf.Sin(get_see.y / 180 * Mathf.PI);
            }
            //右に進む
            if (key_D)
            {
                //rb.AddForce(transform.right * mspeed);
                global_z[3] = mspeed * Mathf.Cos((get_see.y + 90) / 180 * Mathf.PI);
                global_x[3] = mspeed * Mathf.Sin((get_see.y + 90) / 180 * Mathf.PI);
            }
            //左に進む
            if (key_A)
            {
                //rb.AddForce(-transform.right * mspeed);
                global_z[1] = -mspeed * Mathf.Cos((get_see.y + 90) / 180 * Mathf.PI);
                global_x[1] = -mspeed * Mathf.Sin((get_see.y + 90) / 180 * Mathf.PI);
            }

            global.x = global_x[0] + global_x[1] + global_x[2] + global_x[3];
            global.z = global_z[0] + global_z[1] + global_z[2] + global_z[3];
            global.y = rb.velocity.y;

            rb.velocity = global;

            Debug.Log(rb.velocity);
        }
    }
    private void ChageLight()
    {
        isON = !isON;
        UpdateLight();
        // Debug.Log(isON);
    }

    private void UpdateLight()
    {
        player_light.enabled = isON;
    }

    public bool Lightcheck()
    {
        return isON;
    }
}
