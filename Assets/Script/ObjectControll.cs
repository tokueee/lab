using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControll : MonoBehaviour
{
    public GameObject Object;
    public int num = 0;
    private float times = 5.0f;
    private float timer;
    private float settime;
    private bool onetime = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        settime = timer % 6;
        Debug.Log(settime);
        if(settime > times && onetime == false)
        {
            onetime = true;
            //Debug.Log("OK");
            if (Object.activeSelf == true)
            {
                Object.SetActive(false);
            }else if(Object.activeSelf == false)
            {
                Object.SetActive(true);
            }
        }else if(settime < times && onetime == true)
        {
            onetime=false;
        }
        
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            Object.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.R)) 
        {
            Debug.Log("Tu");
            Object.SetActive(true);
        }*/
    }
}
