Shader "Custom/BlurShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurStrength ("Blur Strength", Range(0.0, 1.0)) = 0.5
        _BlurRadius ("Blur Radius", Range(0.0, 10.0)) = 5.0
    }
 
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
 
            #include "UnityCG.cginc"
 
            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            sampler2D _MainTex;
            float _BlurStrength;
            float _BlurRadius;
 
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            fixed4 frag (v2f i) : SV_Target {
                float4 blurColor = float4(0.0, 0.0, 0.0, 0.0);
                float blurSize = _BlurRadius;
                float2 texelSize = 1.0 / _ScreenParams.xy;

                for (float x = -blurSize; x <= blurSize; x += 1.0) {
                    for (float y = -blurSize; y <= blurSize; y += 1.0) {
                        float2 offset = float2(x * texelSize.x, y * texelSize.y);
                        blurColor += tex2D(_MainTex, i.uv + offset);
                    }
                }
                
                blurColor /= ((2 * blurSize + 1) * (2 * blurSize + 1));
                blurColor *= _BlurStrength;

                return blurColor;
            }
            ENDCG
        }
    }
}
