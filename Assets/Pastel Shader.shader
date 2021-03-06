﻿Shader "Custom/NewSurfaceShader"
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

        float3 color = float3(1, x, y);

        float4 result = c;

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
