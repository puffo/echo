Shader "Custom/Ping2" {
    Properties {
        _MainTex ("Main Texture (RGB)", 2D) = "white" {}
        _LightRamp ("Lighting Ramp", 2D) = "white" {}
        _ColourRamp ("Colour Ramp", 2D) = "white" {}
    }

    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        
        
        Pass {
        	Tags { "LightMode" = "ForwardBase" }
        	
        	CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            #include "UnityCG.cginc"

            struct v2f {
                float4 pos :	SV_POSITION;
            }; 

            v2f vert (appdata_full v) {
                v2f o;
                
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                
                return o;
            } 

            float4 frag (v2f i) : COLOR {
            	return float4(0,0,0,0);
            }

            ENDCG
        }
        
        Pass {
            Tags { "LightMode" = "ForwardAdd" }
            Blend One One
            Fog { Color(0,0,0,0) } 

            CGPROGRAM
            #pragma target 3.0
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdadd_fullshadows
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc" 

			sampler2D _MainTex;
			half4 _MainTex_ST;
			sampler2D _LightRamp;
			sampler2D _ColourRamp;

            struct v2f {
                float4 pos :	SV_POSITION;
                half2 uv:		TEXCOORD0;
                LIGHTING_COORDS(1,2)
            }; 

            v2f vert (appdata_full v) {
                v2f o;
                
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                
                TRANSFER_VERTEX_TO_FRAGMENT(o);
                
                return o;
            } 

            float4 frag (v2f i) : COLOR {
            	half4 tex = tex2D(_MainTex, i.uv);
                half atten = LIGHT_ATTENUATION(i);
                half4 light = tex2D(_LightRamp, half2(atten, 0.5));
                
                half lookup = tex.g * light * _LightColor0;
                half4 ramp = tex2D(_ColourRamp, half2(lookup, 0.5));
                
                return ramp;
            }

            ENDCG

        } //Pass

    } //SubShader

    FallBack "Diffuse" //note: for passes: ForwardBase, ShadowCaster, ShadowCollector

}