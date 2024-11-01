using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : MonoBehaviour
{

    public AudioClip[] leg;
    //public AudioClip souns;
    private AudioSource audioSource;


    private GameObject obj; //Playerっていうオブジェクトを探す
    private Player PlayerCS; //呼ぶスクリプトにあだなつける

    public float Savetime; //デバッグ用の表示された数字でどれぐらいの頻度で再生するかの固定値
    private float PbTime;//Playback Time(再生時間)
    private float checktime;
    private bool wait;


    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        obj = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
        PlayerCS = obj.GetComponent<Player>();

        wait = false;
    }

    void Update()
    {
        if (PlayerCS.key_Shift)
        {
            PbTime = Savetime * 0.8f;
        }
        else 
        {
            PbTime = Savetime;
        }
        if (PlayerCS.keyCount != 0)
        {
            if (wait)
            {
                checktime = Time.time;
            }
            //音(sound)を鳴らす
            if (PbTime >= Time.time - checktime && wait)
            {
                
                Get_Sound();
                wait = false;
                Debug.Log("Get_Sounds");
            }
        }
        if (PlayerCS.keyCount == 0 || PbTime < Time.time - checktime)
        {
            wait = true;
        }
        
    }

    private void Get_Sound()//1/25の確率でtrueを返す関数
    {
        //ランダムを一度止めるための変数
        int chance = 25;
        //0からchance-1までのランダムで音声を選んで返す。
        audioSource.PlayOneShot(leg[Random.Range(0, chance)]);
    }
}