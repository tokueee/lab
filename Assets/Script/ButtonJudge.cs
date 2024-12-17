using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJudge : MonoBehaviour
{
    MouseAction action;

    //[SerializeField] private GameObject Prand;//PlayerÇì¸ÇÍÇÈ
    public GameObject[] button;
    public bool[] flag2;
    public Light[] enemyLSpot;
    public Light[] enemyLSpotP;
    /*
    [0] =Spot LightN
    [1] =Spot Light(4)
    [2] =Spot Light(9)
    [3] =Spot Light(12)R
     */
    void Start()
    {
        action = GetComponent<MouseAction>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Getnum(int h)
    {
        //Debug.Log(ran.spone);
        if (button[h] && flag2[h] == false)
        {
            flag2[h] = true;
            //Debug.Log("good");
        }
        else if (button[h] && flag2[h])
        {
            flag2[h] = true;
        }

        /*if (ran.spone)
        {
            enemyLSpot[h].color = Color.red;
            enemyLSpotP[h].color = Color.red;
        }*/
    }
    public void buttonColor(int i)
    {
        button[i].GetComponent<MeshRenderer>().materials[0].color = Color.white;
    }
    public bool butoonjcheck(int k)
    {
        bool check = false;
        switch (k)
        {
            case 0: check = action.Buttonj1(); break;
            case 1: check = action.Buttonj2(); break;
            case 2: check = action.Buttonj3(); break;
            case 3: check = action.Buttonj4(); break;
            case 4: check = action.Buttonj5(); break;
        }
        //Buttonj1Å`5Ç¢Ç∏ÇÍÇ©ÇÃflagÇcheckÇ…ì¸ÇÍÇƒï‘Ç∑
        return check;
    }
}
