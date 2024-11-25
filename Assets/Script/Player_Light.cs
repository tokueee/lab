using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Light : MonoBehaviour
{
    private GameObject obj; //Playerっていうオブジェクトを探す
    private Player PlayerCS; //呼ぶスクリプトにあだなつける

    //ライト用↓
    [SerializeField]
    private GameObject Light;
    [SerializeField]
    private Slider Lightbar;
    private bool isON = false;

    //timer
    public float delLtime = 60;
    public Light Light_main;
    public Light Light_sub;//Renge=100～50 Spot Angle=100～75


    private float[] timer = new float[2];//0=main, 1=sub
    private float[] checktime = {0, 0};
    private float[] time_Elapsed = {0, 0};//経過時間(一度ライトを消したときのため)0=main, 1=sub
    public float Lv_Lm;//Light_main用
    private float[] Lv_Ls = new float[2];//0=Renge, 1=Spot Angle
    private float scale_bar =1;
    //private float time_Elapsed2 = 0;//経過時間(一度ライトを消したときのため)sub

    //private float[] stime = new float[5];
    //private float[] slight = new float[5];

    private bool down_F;
    private bool reset_light;


    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
        PlayerCS = obj.GetComponent<Player>();//obj(Player)に着いたPlayerというCSを代入

        UpdateLight();
        ChargeLight();
        timer[0] = delLtime / 7;
        timer[1] = delLtime;
    }

    // Update is called once per frame
    void Update()
    {
        //手持ちライト制御(meinLight)
        {
            if (0 < Lv_Lm)
            {
                if (isON)
                {
                    //main & sub で利用する確認時間記録　/*ライトを点けたときに一回だけ起動してほしい*/
                    if (!down_F) 
                    {
                        checktime[0] = Time.time;
                        if (reset_light) 
                        {
                            checktime[1] = Time.time;
                            reset_light = false;
                        }
                    }

                    //Debug.Log(timer - (time_Elapsed[0] + Time.time - checktime));

                    //main
                    if (0 >= timer[0] - (time_Elapsed[0] + Time.time - checktime[0]))
                    {
                        Lv_Lm -= 0.5f;
                        time_Elapsed[0] = 0;
                        down_F = false;
                        //Lightbar.value = Lightbar.value - 0.15f;
                        return;//updateの最初から
                    }

                    //sub
                    {
                        Lv_Ls[0] = 75-((75/timer[1]) * (time_Elapsed[1] + Time.time - checktime[1]));
                        Lv_Ls[1] = 25-((25/timer[1]) * (time_Elapsed[1] + Time.time - checktime[1]));
                        scale_bar =1 - ((1 / timer[1]) * (time_Elapsed[1] + Time.time - checktime[1]));
                    }
                    


                }
                if (!isON)
                {
                    //main & sub の経過時間記録　/*ライトを消したときに一回だけ起動してほしい*/
                    if (down_F) 
                    {
                        time_Elapsed[0] = time_Elapsed[0] + Time.time - checktime[0];
                        time_Elapsed[1] = time_Elapsed[1] + Time.time - checktime[1];
                        reset_light = true;
                    }
                }

                
            }
            else
            {
                ChageLight();
            }
            Light_main.intensity = Lv_Lm;
            Light_sub.range = Lv_Ls[0] + 25;
            Light_sub.spotAngle = Lv_Ls[1] + 75;
            Lightbar.value = scale_bar;
            down_F = isON;
        }
    }

    public void ChageLight()
    {
        if (0 < Lv_Lm)
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

    public void UpdateSystem()
    {   
        Lightbar.value = scale_bar;
    }

    public bool Lightcheck()
    {
        return isON;
    }
    
    public void ChargeLight()
    {
        this.Lv_Lm = 3.5f;
        this.Lv_Ls[0] = 50;
        this.Lv_Ls[1] = 25;
        this.reset_light = true;
        this.time_Elapsed[1] = 0;
        this.scale_bar = 1;
        this.down_F = false;
    }

}
