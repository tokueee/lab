using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Lightset : MonoBehaviour
{
    // GameObject mylight;
    public Light mylight;
    public Light[] lights;
    public float dspeed = 0.1f;
    public float minlight = 1.0f;
    public float minDelay = 1.1f; 
    public float maxDelay = 3.0f;
    private float[] time;
    public int[] diminorder;

    // Start is called before the first frame update
    void Start()
    {
        int lightcount = lights.Length;
        time = new float[lightcount];
        //mylight = GetComponent<Light>();
        for ( int i = 0; i < lightcount; i++)
        {
            time[i] = Random.Range(minDelay, maxDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Light[] lights = FindObjectsOfType<Light>();
        foreach (int i in diminorder) 
        {
            if(i < 0 || i >= lights.Length) continue;

            time[i] = Time.deltaTime;

            if (time[i] < minlight)
            {
                lights[i].intensity -= dspeed * Time.deltaTime;
                if (lights[i].intensity < minlight)
                {
                    lights[i].intensity = minlight;
                }
                time[i] = Random.Range(minDelay, maxDelay);
            }
        }
    }
}
