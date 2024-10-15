using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


public class Lightset : MonoBehaviour
{

    public Light[] mylight;
    private float minlight = 0.0f;
    private float maxlight = 3.7f;
    public float starttime;
    public float dtime;
    public float keyDtime;
    int i = 0;
    int lightoffCount = 1;
    int count =0;

    Player playerscript;

    // Start is called before the first frame update
    void Start()
    {
        //mylight = gameObject.GetComponent<Light[]>();
        GameObject player = GameObject.Find("Capsule");
        playerscript = player.GetComponent<Player>();
    }

   

    IEnumerator lighting()
    {
        for (i = 0; i < mylight.Length; i++)
        {
            if (mylight[i] != null)
            {
                mylight[i].intensity -= 0.005f;
                

                if (mylight[i].intensity < minlight)
                {
                    mylight[i].intensity = minlight;
                    //Debug.Log("OK");
                }
                //Debug.Log(mylight[i]);
            }
            yield return new WaitForSeconds(dtime);
            //Debug.Log("true");
            
        }
        
        //Debug.Log("OK");
    }

    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(starttime);
        mylight[0].intensity = minlight;
        yield return new WaitForSeconds(dtime);
        for(int j = 1;j < mylight.Length;j++)
        {
            mylight[j].intensity = minlight;
            //Debug.Log(j);
            yield return new WaitForSeconds(dtime);
        }
    }

    IEnumerator Keyboard_LightOn()
    {
        /*for (int k = 0; k < mylight.Length; k++)
        {
            mylight[k].intensity = maxlight;
            yield return new WaitForSeconds(keyDtime);
        }*/
        mylight[0].intensity = maxlight;
        mylight[1].intensity = maxlight;
        mylight[2].intensity = maxlight;
        yield return new WaitForSeconds(keyDtime);
        StartCoroutine(Keyboad_LightOff());
        //Debug.Log(mylight[0]);
    }

    IEnumerator Keyboad_LightOff()
    {
        for (int k = 0; k < mylight.Length; k++)
        {
            mylight[k].intensity = minlight;
            yield return new WaitForSeconds(keyDtime);
        }
    }

    /*void lightingset()
    {
        for (i = 0; i < mylight.Length; i++)
        {
            if (mylight[i] != null)
            {
                //mylight[i].intensity -= 0.001f;

                if (mylight[i].intensity < minlight)
                {
                    mylight[i].intensity = minlight;
                    //Debug.Log("OK");
                }
                else
                {
                    mylight[i].intensity -= 0.001f;
                }
                Debug.Log(mylight[i]);
            }
            //StartCoroutine(Wait());
            //Debug.Log("true");
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(lighting());
        if(lightoffCount > count)
        {
            if (mylight[mylight.Length - 1].intensity > 0)
            {
                StartCoroutine(LightOff());
                count++;
            }
        }
        if (mylight[0].intensity == minlight)
        {
            if(playerscript.flag == true)
            {
                //Debug.Log("ON");
                StartCoroutine(Keyboard_LightOn());
            }
            /*if (Input.GetKeyDown(KeyCode.O))
            {
                //Debug.Log(mylight[0].intensity);
                StartCoroutine(Keyboard_LightOn());
            }*/
        }
        /*else if (mylight[0].intensity == maxlight)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log(mylight[0].intensity);
                StartCoroutine(Keyboad_LightOff());
            }
        }*/

        //lightingset();

        
        /*if (mylight[0].intensity > 1)
        {
            mylight[0].intensity = mylight[0].intensity - Time.deltaTime;
        } else
        {
            mylight[1].intensity = mylight[1].intensity - Time.deltaTime;
        }*/
        //mylight[0].intensity = mylight[0].intensity - Time.deltaTime;

    }
}
