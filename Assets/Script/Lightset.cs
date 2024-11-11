using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


public class Lightset : MonoBehaviour
{ 
    private float minlight = 0.0f;
    private float maxlight = 3.7f;

    private float timer = 60.0f;
    private float times;
    private float timer2;
    private float[] stime = new float[5];
    private float[] slight = new float[5];
    //private int p = 7;
    //private float[] ftime;

    public float starttime;
    public float dtime;
    public float keyDtime;
    public GameObject buttons;
    public Light flight;
    public Light[] mylight;
    //int i = 0;
    int lightoffCount = 1;
    int count =0;

    MouseAction mouseaction;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = GameObject.Find("Player");//ñºëOïœçXÇ…íçà”
        mouseaction = buttons.GetComponent<MouseAction>();
        //stime[0] = timer - 10.0f;//10ïbå„Ç…ñæÇÈÇ≥Çâ∫Ç∞ÇÈÇΩÇﬂÇÃèâä˙ê›íË
        slight[0] = 3.5f;
        for(int i = 0; i < stime.Length; i++)
        {
            timer2 = timer - (10 * (i+1));
            stime[i] = timer2;
            //Debug.Log("i =" +stime[i]);
        }
    }

   

    /*IEnumerator lighting()
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
    }*/

    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(starttime);
        mylight[0].intensity = minlight;
        yield return new WaitForSeconds(dtime);
        mylight[1].intensity = minlight;
        mylight[2].intensity = minlight;
        yield return new WaitForSeconds(dtime);
        for(int j = 0;j < mylight.Length;j++)
        {
            if (mylight[j].intensity == maxlight)
            {
                if (mylight[j] == mylight[6])
                {
                    mylight[6].intensity = minlight;
                    mylight[7].intensity = minlight;
                    mylight[16].intensity = minlight;
                    yield return new WaitForSeconds(dtime);
                }else if (mylight[j] == mylight[8])
                {
                    mylight[8].intensity = minlight;
                    mylight[9].intensity = minlight;
                    mylight[17].intensity = minlight;
                    yield return new WaitForSeconds(dtime);
                }
                if (mylight[j] == mylight[10])
                {
                    mylight[10].intensity = minlight;
                    mylight[12].intensity = minlight;
                    mylight[18].intensity = minlight;
                    yield return new WaitForSeconds(dtime);
                }
                if (mylight[j] == mylight[11])
                {
                    mylight[11].intensity = minlight;
                    mylight[13].intensity = minlight;
                    mylight[19].intensity = minlight;
                    yield return new WaitForSeconds(dtime);
                }
                mylight[j].intensity = minlight;
                yield return new WaitForSeconds(dtime);
            }
        }
    }

    IEnumerator Keyboard_LightOn()
    {
        if (mouseaction.Buttonj2() == true)
        {
            Debug.Log("ON");
            mylight[4].intensity = maxlight;
            mylight[16].intensity = maxlight;
            mylight[17].intensity = maxlight;
            mylight[18].intensity = maxlight;
            
            yield return new WaitForSeconds(keyDtime);
            StartCoroutine(Keyboad_LightOff2());
        }
        if (mouseaction.Buttonj1() == true)
        {
            if (mylight[2].intensity == minlight)
            {
                mylight[0].intensity = maxlight;
                mylight[1].intensity = maxlight;
                mylight[2].intensity = maxlight;
                yield return new WaitForSeconds(keyDtime);
                StartCoroutine(Keyboad_LightOff());
            }
            //Debug.Log(playerscript.flag);
        }

        //Debug.Log(mylight[0]);
    }

    IEnumerator Keyboad_LightOff2() 
    {
        mylight[4].intensity = minlight;
        for(int i = 16; i < 4; i++) 
        {
            //Debug.Log(i);
            mylight[i].intensity = minlight;
            yield return new WaitForSeconds(keyDtime);
        }
    }

    IEnumerator Keyboad_LightOff()
    {
        for (int k = 0; k < mylight.Length; k++)
        {
            mylight[k].intensity = minlight;
            yield return new WaitForSeconds(keyDtime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Mouse X"));
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
            if (mouseaction.Buttonj1() == true)
            {
                //Debug.Log("ON");
                StartCoroutine(Keyboard_LightOn());
            }
            if (mouseaction.Buttonj2() == true)
            {
                StartCoroutine(Keyboard_LightOn());
            }
        }
        /*if (flight.intensity  > 0)
        {
            times =timer - Time.time;
            //Debug.Log(times);
            if (times < stime[0] && times > stime[1])
            {
                slight[0] = 3.0f;
                flight.intensity = slight[0];
            }else if (times < stime[1] &&  times > stime[2])
            {
                slight[1] = 2.5f;
                flight.intensity = slight[1];
            }else if(times < stime[2] && times > stime[3])
            {
                slight[2] = 2.0f;
                flight.intensity = slight[2];
            }else if(times < stime[3] && times > stime[4])
            {
                slight[3] = 1.5f;
                flight.intensity = slight[3];
            }
            else if(times < stime[4])
            {
                slight[4] = 1.0f;
                flight.intensity = slight[4];
            }
            if (times < 0)
            {
                flight.intensity = 0;
                times = 0.0f;
            }
            /*if(times  < 0)
            {
                timer = 10;
                p -= 1;
                flight.intensity = p * 0.5f;
                Debug.Log("P="+ p);
            }
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                flight.intensity = 0.0f;
            }
        }
        else if (flight.intensity == 0.0f && Input.GetKeyDown(KeyCode.F))
        {
            flight.intensity = slight[0];
            if (times < stime[0] && times > stime[1])
            {
                slight[0] = 3.0f;
                flight.intensity = slight[0];
            }
            else if (times < stime[1] && times > stime[2])
            {
                slight[1] = 2.5f;
                flight.intensity = slight[1];
            }
            else if (times < stime[2] && times > stime[3])
            {
                slight[2] = 2.0f;
                flight.intensity = slight[2];
            }
            else if (times < stime[3] && times > stime[4])
            {
                slight[3] = 1.5f;
                flight.intensity = slight[3];
            }
            else if (times < stime[4] && times > 0)
            {
                slight[4] = 1.0f;
                flight.intensity = slight[4];
            }
            if (times < 0)
            {
                flight.intensity = 0.0f;
                times = 0.0f;
            }
        }*/
    }
}
