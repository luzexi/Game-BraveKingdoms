Shader "Custom/NoLightingEffect/Transparent_Add" {
	Properties {
		_MainTex ("Texture 0", 2D) = "white" {}
		_MainTex1 ("Texture 1", 2D) = "white" {}
		_Alpha ("Alpha", Range(0, 1.0)) = 1.0
		_Color("color",color) = (1,1,1,1)
	}
	SubShader {
		Tags { "Queue"="Transparent+1" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 200
		
		Lighting Off 
		Blend One One 
		Cull Off 
		ZWrite Off 
		Fog { Mode Off }
		
		Pass {
			CGPROGRAM
			// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
			#pragma exclude_renderers gles
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "NoLightingEffect.cginc"
			
			fixed4 _Color;
			
			NoLightingEffect_v2f vert (appdata_full v)
			{
			    return NoLightingEffect_VS(v);
			}
			fixed4 frag (NoLightingEffect_v2f i) : COLOR
			{
//			    return NoLightingEffect_Modulate_PS(i);
				return _Color* NoLightingEffect_Modulate_PS(i);
			}
			ENDCG
		}
		
	} 
	FallBack "Transparent/Diffuse"
}