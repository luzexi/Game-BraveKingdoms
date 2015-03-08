Shader "Custom/AlphaVerList" {  
    Properties {  
        _Color ("Main Color", Color) = (1,1,1,1)
		_SpecColor ("Spec Color", Color) = (1,1,1,1)
		_Emission ("Emissive Color", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (0.125,0.125,0.125,1)  
        _Outline ("Outline width", Float) = .0002  
        _MainTex ("Base (RGB)", 2D) = "white" { }  
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5  
    }  
    CGINCLUDE  
        #include "UnityCG.cginc"  
        struct appdata {  
            float4 vertex : POSITION;  
            float3 normal : NORMAL;  
        };  
        struct v2f {  
            float4 pos : POSITION;  
            float4 color : COLOR;  
        };  
        uniform float _Outline;  
        uniform float4 _OutlineColor;  
        v2f vert(appdata v) {  
            v2f o;  
            o.pos = mul(UNITY_MATRIX_MVP, v.vertex);  
            float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);  
            float2 offset = TransformViewToProjection(norm.xy);  
            o.pos.xy += offset * o.pos.z * _Outline;  
            o.color = _OutlineColor;  
            return o;  
        }  
    ENDCG  
    SubShader {  
        Tags { "Queue" = "Transparent" "IgnoreProjector"="True" "RenderType"="TransparentCutout" }
        Pass {  
            Tags { "LightMode" = "Vertex"  }  
			Alphatest Greater [_Cutoff]  
            Cull Off  
            ZWrite Off  
            //ZTest Always//始终通过深度测试，即可以渲染  
            //ColorMask RGB // alpha not used  
            Blend SrcAlpha OneMinusSrcAlpha // Normal  
      
            CGPROGRAM  
            #pragma vertex vert  
            #pragma fragment frag  
            half4 frag(v2f i) :COLOR {  
                return i.color;  
            }  
            ENDCG  
			SetTexture [_MainTex] {  
                Combine previous * primary DOUBLE  , texture * primary   
            }  
        }  
        Pass {  
			Tags { "LightMode" = "Vertex" }  
			Alphatest Greater [_Cutoff]  
            Name "BASE"  
            ZWrite On ZTest LEqual Cull Off  
			Cull Off  
            Blend SrcAlpha OneMinusSrcAlpha  
            Material {  
                Diffuse [_Color]  
                Ambient [_Color]  
				Shininess [_Shininess]
				Specular [_SpecColor]
				Emission [_Emission]
            }  
            Lighting On  
            SetTexture [_MainTex] {  
                ConstantColor [_Color]  
                Combine texture * constant  
            }  
            SetTexture [_MainTex] {  
                Combine previous * primary DOUBLE  , texture * primary   
            }  
        }  
    }  
    Fallback "Diffuse"  
}  
