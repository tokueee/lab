using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


public class Lightset : MonoBehaviour
{ 
    private float minlight = 0.0f;
    private float maxlight = 3.7f;
    public float starttime;
    public float dtime;
    public float keyDtime;
    public GameObject player;
    public Light[] mylight;
    //int i = 0;
    int lightoffCount = 1;
    int count =0;
    int oncount;
    bool cflag;

    Player playerscript;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = GameObject.Find("Player");//ñºëOïœçXÇ…íçà”
        Debug.Log(player);
        playerscript = player.GetComponent<Player>();
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
        if (playerscript.flags[1] == true)
        {
            mylight[4].intensity = maxlight;
            mylight[16].intensity = maxlight;
            mylight[17].intensity = maxlight;
            mylight[18].intensity = maxlight;
            
            yield return new WaitForSeconds(keyDtime);
            StartCoroutine(Keyboad_LightOff2());
        }
        if (playerscript.flags[0] == true)
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
        //Debug.Log(dtime);
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
            if (playerscript.flags[0] == true)
            {
                //Debug.Log("ON");
                StartCoroutine(Keyboard_LightOn());
            }
            if (playerscript.flags[1] == true)
            {
                StartCoroutine(Keyboard_LightOn());
            }
        }
    }
}
