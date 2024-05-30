Shader "Custom/OutlineShader"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineThickness ("Outline Thickness", Range (0.0, 0.03)) = 0.005
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            // Cull Front
            Cull Front

            // Outline
            Name "OUTLINE"
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite On
            ColorMask RGB
            Offset 2, 2

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float4 color : COLOR;
            };

            uniform float _OutlineThickness;
            uniform float4 _OutlineColor;

            v2f vert (appdata v)
            {
                // Calculate vertex position in world space
                v2f o;
                float3 norm = mul((float3x3)unity_ObjectToWorld, v.normal);
                o.pos = UnityObjectToClipPos(v.vertex + float4(norm * _OutlineThickness, 0));
                o.color = _OutlineColor;
                return o;
            }

            half4 frag (v2f i) : COLOR
            {
                return i.color;
            }
            ENDCG
        }
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float4 color : COLOR;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = float4(1,1,1,1);
                return o;
            }

            half4 frag (v2f i) : COLOR
            {
                return i.color;
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
}
