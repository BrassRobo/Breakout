Shader "Custom/RainbowShader"
{
    Properties
    {
         _MainTex("Base (RGB)", 2D) = "white" {}
         _intensity("Intensity", Range(0, 1)) = 0
    }
        SubShader{
        Pass {
        CGPROGRAM
        #pragma vertex vert_img
        #pragma fragment frag

        #include "UnityCG.cginc"

        uniform sampler2D _MainTex;
        uniform float _intensity;

        float4 frag(v2f_img i) : COLOR {
        float4 c = tex2D(_MainTex, i.uv);

        float x = i.uv.x;
        float y = i.uv.y;

        float3 color = c;

        if (y <= 0.333) //Red -Yellow
        {
            color = float3(1, y * 3.003, 0);
        }
        else if (y<= 0.5 ) //Green
        {
            color = float3((y*-6) + 3, 1, 0);
        }
        else if (y < 0.666)//Light Blue
        {
            color = float3(0, 1, (y*6)-3);
        }
        else if (y < 0.833)//Dark Blue
        {
            color = float3(0, (y * -6) + 5, 1);
        }
        else //Magenta
        {
            color = float3((6*y)-5, 0, 1);
        }
        float4 result = c;

        //If the pixel isn't black.
        if (c.r != 0 && c.g != 0 && c.b != 0)
        {
            result.rgb = lerp(c.rgb, color, _intensity);
        }
        return result;
        }
        ENDCG
        }
         }
             FallBack "Diffuse"
}

