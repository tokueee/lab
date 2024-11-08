using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Light : MonoBehaviour
{
    private GameObject obj; //Playerっていうオブジェクトを探す
    private Player PlayerCS; //呼ぶスクリプトにあだなつける

    //ライト用↓
    [SerializeField]
    private GameObject Light;
    private bool isON = false;

    //timer
    public float delLtime = 60;
    public Light flight;
    private float timer;
    private float checktime = 0;
    private float time_Elapsed = 0;//経過時間(一度ライトを消したときのため)
    private float Lv_light;//flight用

    //変数を追加しただけだよ↓
    public Light flash;//Renge=100～50 Spot Angle=100～75
    private float[] Lv_flash = new float[2];//0=Renge, 1=Spot Angle

    //private float[] stime = new float[5];
    //private float[] slight = new float[5];

    bool down_F;


    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
        PlayerCS = obj.GetComponent<Player>();//obj(Player)に着いたPlayerというCSを代入

        //Light = GameObject.Find("flashlight");
        UpdateLight();

        timer = delLtime / 7;

        Lv_light = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //手持ちライト制御
        {
            if (0 < Lv_light)
            {
                if (isON && Lv_light >= 0)
                {
                    if (!down_F) { checktime = Time.time; }
                    Debug.Log(timer - (time_Elapsed + Time.time - checktime));
                    if (0 >= timer - (time_Elapsed + Time.time - checktime))
                    {
                        Lv_light -= 0.5f;
                        time_Elapsed = 0;
                        down_F = false;
                        //Debug.Log("down_F");
                        return;
                    }

                }
                if (!isON)
                {
                    if (down_F) { time_Elapsed = time_Elapsed + Time.time - checktime; }
                }
                
            }
            else
            {
                ChageLight();
            }
            flight.intensity = Lv_light;


            down_F = isON;
        }
    }

    public void ChageLight()
    {
        if (0 < Lv_light)
        {
            isON = !isON;
        }
        else
        {
            isON = false;
        }
        UpdateLight();
        // Debug.Log(isON);
    }

    public void UpdateLight()
    {
        //player_light.enabled = isON;
        Light.SetActive(isON);
    }

    public bool Lightcheck()
    {
        return isON;
    }
    
    private void ChargeLight()
    {
        Lv_light = 3.5f;

    }
}
