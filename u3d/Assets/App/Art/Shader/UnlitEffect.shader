Shader "Custom/UnlitEffect" {
	Properties {
		_MainTex ("Texture 0", 2D) = "white" {}
		_MainTex1 ("Texture 1", 2D) = "white" {}
		_Alpha ("Alpha", Range(0, 1.0)) = 1.0
		_Color("color",color) = (1,1,1,1)
	}
	SubShader {
		Tags {
		"Queue"="Transparent+1" 
		"IgnoreProjector"="True" 
		"RenderType"="Transparent" 
		}
		LOD 200
		Lighting Off 
		Blend One One 
		Cull Off 
		ZWrite Off 
		Fog { Mode Off }
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _MainTex1;
		float4 _Color;
		float _Alpha;
		
		
		struct Input {
			float2 uv_MainTex;
			float2 uv_MainTex1;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c1 = tex2D (_MainTex, IN.uv_MainTex);
			half4 c2 = tex2D (_MainTex1, IN.uv_MainTex1);
			
			o.Albedo = c1.rgb * c2.rgb * _Color;
			o.Emission = o.Albedo;
			o.Alpha = c1.a * c2.a* _Alpha;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
