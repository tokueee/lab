using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraNoise : MonoBehaviour
{  
    
    //MainCameraにアタッチしてNoiseMateを設定する
    public Material noiseMaterial;
    [Range(0, 1)]
    float noiseAmount = 0.1f;//publicの優先度が高いためpublicを使っていない
    Color noiseColor = Color.white;

    private float timer;
    private float set_time;
    private float times = 6.0f;
    private bool oneTime = false;
    void Start()
        {

        }
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (noiseMaterial != null)
        {
            // ノイズの強さを調整
            noiseMaterial.SetFloat("_NoiseAmount", noiseAmount);

            noiseMaterial.SetColor("_NoiseColor", noiseColor);
            //Debug.Log(noiseColor);
            // ノイズエフェクトをカメラのレンダリングに適用
            Graphics.Blit(src, dest, noiseMaterial);
            
        }
        else
        {
            // ノイズマテリアルがない場合はそのまま描画
            Graphics.Blit(src, dest);
        }
    }
  

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        set_time = timer % 11;
        if(set_time > times && oneTime == false)
        {
            oneTime = true;
            noiseColor = Color.red;
        }else if(set_time < times && oneTime == true)
        {
            oneTime= false;
            noiseColor = Color.white;
        }
        Debug.Log(set_time);

    }
}
