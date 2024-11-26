using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battelys : MonoBehaviour
{
    //(数列の要素数分オブジェクトを追加しようとした痕跡)
    //public GameObject prefab;
    //public List<int> myList = new List<int>();


    public GameObject[] Battely;
    public float TurnTime = 0.25f;
    private GameObject Player;
    private Player_Light PL;
    private int battely_num;
    private int before_num;
    private bool[] check;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PL = Player.GetComponent<Player_Light>() ;
        Reset_battelys();
        
        check = new bool[Battely.Length];
        for(int p=0; p<Battely.Length; p++)
        {
            check[p] = true;
        }

        // 数列に適当な値を追加(数列の要素数分オブジェクトを追加しようとした痕跡)
        {
            /*
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            // 数列のLength分ループ
            for (int i = 0; i < myList.Count; i++)
            {
                // プレハブをインスタンス化
                //GameObject instance = Instantiate(prefab);
                GameObject obj = (GameObject)object.Load("Cube");
                // インスタンスの位置を設定 (例: x座標のみ変化させる)
                //instance.transform.position = new Vector3(i * 2, 0, 0);
                Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
            }*/
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (battely_num != -1)
        {
            if(battely_num != before_num)
            {
                PL.ChargeLight();
                //PL.UpdateSystem();
                Battely[battely_num].SetActive(false);
                check[battely_num] = false;
                Debug.Log("get_battely");
            }
        }
        
        for(int i = 0; i < Battely.Length; i++) 
        {
            if (check[i])
            {
                float turn = Battely[i].transform.localEulerAngles.z + TurnTime;//batteryオブジェクトのRotation.Yを取得しturnTimeを追加
                if (turn >= 360) { turn -= 360; }
                Battely[i].transform.Rotate(0f, 0f, turn);
            }
            else if (!check[i]) { Debug.Log("after"+i); }
        }
        before_num = battely_num;
        battely_num = -1;
        
    }

    public void Get_num(int num)
    {
        this.battely_num = num;
    }

    public void Reset_battelys()
    {
        battely_num = -1;
        before_num = battely_num;
        for (int i=0;i<Battely.Length;i++)
        {
            Battely[i].SetActive(true);
        }
    }
}

