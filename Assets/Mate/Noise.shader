Shader "Unlit/Noise"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        /*_NoiseAmount ("Noise Amount", Range(0, 1)) = 0.5
        _NoiseColor ("Noise Color", Color) = (1, 1, 1, 1)*/
        _Speed ("Speed", Float) = 1.0
        //_Scale ("Scale", Float) = 20.0
        _Intensity ("Intensity", Float) = 0.05
        _Color ("Sand Color", Color) = (1.0, 0.8, 0.6, 0.5)
        _Transparency ("Transparency", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha 
            ZWrite Off 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            //#pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                //UNITY_FOG_COORDS(1)
                float4 pos : SV_POSITION;
            };

            sampler2D _MainTex;
            /*float4 _MainTex_ST;
            float _NoiseAmount;
            fixed4 _NoiseColor;*/
            float _Speed;
            //float _Scale;
            float _Transparency;
            float _Intensity;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                //o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv = v.uv; //* _Scale;
                //UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float rand(float2 p)
            {
                return frac(sin(dot(p, float2(12.9898, 78.233))) * 43758.5453);
            }

             float noise(float2 p)
            {
                float2 i = floor(p);
                float2 f = frac(p);

                float a = rand(i);
                float b = rand(i + float2(1.0, 0.0));
                float c = rand(i + float2(0.0, 1.0));
                float d = rand(i + float2(1.0, 1.0));

                float2 u = f * f * (3.0 - 2.0 * f);

                return lerp(a, b, u.x) + (c - a) * u.y * (1.0 - u.x) + (d - b) * u.x * u.y;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 bgColor = tex2D(_MainTex, i.uv);
                
                float2 uv1 = i.uv + float2(_Time.x * _Speed, _Time.x * _Speed * 0.5);
                float2 uv2 = i.uv + float2(-_Time.x * _Speed * 0.7, _Time.x * _Speed);
                float2 uv3 = i.uv + float2(_Time.x * _Speed * 0.3, -_Time.x * _Speed * 0.8);

                float n1 = noise(uv1*200.0);
                float n2 = noise(uv2*200.0);
                float n3 = noise(uv3*200.0);

                float finalNoise = (n1 + n2 + n3) / 3.0;

                finalNoise = (n1 + n2 + n3) * _Intensity;

                float intensity = step(0.5, finalNoise) * _Intensity;

                float alpha = intensity * _Transparency;

                float4 sandstormColor = float4(_Color.rgb, alpha);
                return lerp(bgColor, sandstormColor, alpha);
                
                /*fixed4 col = tex2D(_MainTex, i.uv);
                
                //UNITY_APPLY_FOG(i.fogCoord, col);
                float noise = rand(i.uv) * _NoiseAmount;

                fixed4 noiseColor = _NoiseColor * noise;

                col.rgb += noiseColor.rgb;
                return col;*/
            }
            ENDCG
        }
    }
    FallBack "Transparent"
}
