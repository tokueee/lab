using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJudge : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Getnum(int h)
    {
        if (button[h] && flag2[h] == false)
        {
            flag2[h] = true;
            //Debug.Log("good");
        }
        else if (button[h] && flag2[h])
        {
            flag2[h] = true;
        }
        enemyLSpot[h].color = Color.red;
        enemyLSpotP[h].color = Color.red;
    }
}
