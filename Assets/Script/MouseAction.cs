using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction : MonoBehaviour
{
    //マウスのX座標
    private float mpos_x;
    private float mposmax_x = 680;
    private float mposmin_x = 600;
    
    //マウスのY座標
    private float mpos_y;
    private float mposmax_y = 410;
    private float mposmin_y = 320;
    ButtonJudge buttons;

    private float times;
    private float stimer;
    private bool mremove = false;
    // Start is called before the first frame update
    void Start()
    {
        buttons = FindObjectOfType<ButtonJudge>();
        //Debug.Log(buttons.button[1]);
        //Debug.Log(buttons.flag2);
    }
    public bool Buttonj1()
    {
        return buttons.flag2[0];
    }

    public bool Buttonj2()
    {
        return buttons.flag2[1];
    }

    // Update is called once per frame
    void Update()
    {
        mpos_x = Input.mousePosition.x;
        mpos_y = Input.mousePosition.y;
        //Debug.Log(mpos_y);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,5.0f))
            {
                //buttons = hit.collider.GetComponent<ButtonJudge>();
                if (buttons != null)
                {
                    if (hit.collider.gameObject == buttons.button[0])
                    {
                        if (buttons.button[0] && buttons.flag2[0] == false)
                        {
                            buttons.flag2[0] = true;
                            buttons.flag2[1] = false;
                            //Debug.Log("good");
                        }
                        else if (buttons.button[0] && buttons.flag2[0])
                        {
                            buttons.flag2[0] = true;
                        }
                        Buttonj1();
                    }
                    /*else if (buttons.button[0] && buttons.flag2[0])
                    {
                        buttons.flag2[0] = false; 
                    }*/
                    if (hit.collider.gameObject == buttons.button[1])
                    {
                        if (buttons.button[1]  && buttons.flag2[1] == false)
                        {
                            buttons.flag2[1] = true;
                            buttons.flag2[0] = false;
                        }
                        else if (buttons.button[1] && buttons.flag2[1])
                        {
                            buttons.flag2[1] = true;
                        }
                        Buttonj2();
                    }
                    
                    /*else if (buttons.button[1] && buttons.flag2[1])
                    {
                        buttons.flag2[1] = false; 
                    }*/
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5,false);
        }

        if(Input.GetMouseButtonUp(0))
        {
            if (buttons != null)
            {
                if (buttons.flag2[0] || buttons.flag2[1])
                 {
                    mremove = true;
                    //buttons.flag2[0] = false ;
                 }
            }
        }
        
        if (mremove)
        {
            times = Time.time;
            stimer = times % 20.1f;
            //Debug.Log(stimer);
            if(stimer > 20)
            {
                mremove = false;
                buttons.flag2[0] = false;
                buttons.flag2[1] = false;
            }
        }
        if (mpos_x >= mposmin_x && mpos_y >= mposmin_y && mpos_x <= mposmax_x && mpos_y <= mposmax_y)
        {
            //Debug.Log(Input.mousePosition);
            /*if (players != null)
            {
                Debug.Log(hit.collider.transform.position);
            }*/
        }
        
    }
}
