using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.tvOS;
using static UnityEditor.PlayerSettings;

public class flicker_Light : MonoBehaviour
{
    public Light targetLight; // 揺らぎを加えるライト
    private float flickerSpeed; // 揺らぎの速度
    private float intensityMin; // 最小強度
    private float intensityMax; // 最大強度

    private float time;
    private float distans;
    [SerializeField] private GameObject player;
    [SerializeField] Player_Light p_light;
    [SerializeField] private GameObject Lenemy;

    // Start is called before the first frame update
    private float cdists = 10.0f;
    private float mdists = 20.0f;
    private float fcdists = 30.0f;
    private float fdists2 = 40.0f;
    private float noise;
    private float times;
    private float stimer;

    private int cset;

    //距離に応じて返す関数
    private int DisNum3(float dist)
    {
        if (dist < cdists) return 0;
        if (dist < mdists) return 1;
        if (dist < fcdists) return 2;
        if (dist < fdists2) return 3;
        return 4;
    }
    private float Dlight_i(float distnum)
    {

        switch (distnum)
        {
            //disnumの値に応じて実行する
            case 0:
                flickerSpeed = 1.5f; return flickerSpeed;
            case 1:
                flickerSpeed = 1.2f; return flickerSpeed;
            case 2:
                flickerSpeed = 0.9f; return flickerSpeed;
            case 3:
                flickerSpeed = 0.6f; return flickerSpeed;
            case 4:
                flickerSpeed = 0.3f; return flickerSpeed;
            default:
                flickerSpeed = 0.0f; return flickerSpeed;
        }
    }
    void Start()
    {
        targetLight = GetComponent<Light>();
        p_light = player.GetComponent<Player_Light>();
        time = 0.0f;
        intensityMax = p_light.Light_main.intensity;
        intensityMin = 0.0f;
        cset = Random.Range(0, 2) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetLight != null)
        {
            distans = Vector3.Distance(Lenemy.transform.position, player.transform.position);
            int inum = DisNum3(distans);
            float dis_i = Dlight_i(inum);
            //Debug.Log(flickerSpeed);
            // 時間をベースにして揺らぎを生成
            time += Time.deltaTime * dis_i;
            switch (cset)
            {
                case 1:
                    noise = (2 - (time * 2)) % 2; break;
                case 2:
                    noise = (3 - (time * 2)) % 3; break;
                case 3:
                    p_light.Light_sub.intensity = p_light.Light_main.intensity;
                    times = Time.deltaTime;
                    stimer = stimer + (times % 4.1f);
                    //Debug.Log(stimer);
                    if (stimer > 3)
                    {
                        p_light.Light_main.intensity = 0;
                        p_light.Light_sub.intensity = p_light.Light_main.intensity;
                        if (stimer > 4)
                        {
                            noise = 0.0f;
                        }
                    }
                    break;
            }
            //noise = (2 - (time * 2)) % 2;
            if(noise <= 0) 
            {
                noise = 2; 
                time = 0.0f;
                cset = Random.Range(0, 3) + 1;
                Debug.Log(cset);
            }
            //Debug.Log(cset);
            if(!(cset == 3))
            {
                p_light.Light_main.intensity = Mathf.Lerp(intensityMin, intensityMax, noise);
                p_light.Light_sub.intensity = p_light.Light_main.intensity;
                intensityMax = p_light.Lv_Lm;
            }
        }
    }
}
