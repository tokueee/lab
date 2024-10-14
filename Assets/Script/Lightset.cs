using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


public class Lightset : MonoBehaviour
{

    public Light[] mylight;
    private float minlight = 1.0f;
    private float dtime = 5.0f;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        //mylight = gameObject.GetComponent<Light[]>();
    }

    IEnumerator lighting()
    {
        for (i = 0; i < mylight.Length; i++)
        {
            if (mylight[i] != null)
            {
                mylight[i].intensity -= 0.001f;
                yield return new WaitForSeconds(dtime);

                if (mylight[i].intensity < minlight)
                {
                    mylight[i].intensity = minlight;
                    //Debug.Log("OK");
                }
                Debug.Log(mylight[i]);
            }
            //yield return new WaitForSeconds(dtime);
            //Debug.Log("true");
        }
        //yield return new WaitForSeconds(dtime);
        Debug.Log("OK");
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
        StartCoroutine(lighting());
        //lightingset();
        /*for(i =0; i < mylight.Length; i++) 
        {
            if (mylight[i] != null)
            {
                mylight[i].intensity -= 0.01f;

                if (mylight[i].intensity < minlight)
                {
                    mylight[i].intensity = minlight;
                    //Debug.Log("OK");
                }
                //Debug.Log(mylight[i]);
            }
            //StartCoroutine( Wait() );
        }*/
        //Debug.Log("finish");
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
