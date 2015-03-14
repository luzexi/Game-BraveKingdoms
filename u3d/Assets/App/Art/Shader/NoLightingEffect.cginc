sampler2D _MainTex;
sampler2D _MainTex1;
float _Alpha;

struct NoLightingEffect_v2f {
    float4 pos : SV_POSITION;
    float2 uv0 : TEXCOORD0;
    float2 uv1 : TEXCOORD1;
    fixed4 color : COLOR;
};

float4 _MainTex_ST;
float4 _MainTex1_ST;

NoLightingEffect_v2f NoLightingEffect_VS (appdata_full v)
{
    NoLightingEffect_v2f o;
    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
    o.uv0 = TRANSFORM_TEX(v.texcoord, _MainTex);
    o.uv1 = TRANSFORM_TEX(v.texcoord1, _MainTex1);
    o.color = v.color;
    return o;
}
fixed4 NoLightingEffect_Layer_PS (NoLightingEffect_v2f i)
{
	fixed4 color0 = tex2D(_MainTex, i.uv0);
    fixed4 color1 = tex2D(_MainTex1, i.uv1);
    
    float ax = 1 - ( 1 - color0.a - color1.a + color0.a*color1.a);
    fixed4 rltRGB = (color0.a*(1 - color1.a)*color0 + color1.a*color1) / ax;
    return fixed4(rltRGB.rgb*i.color.rgb, ax*i.color.a*_Alpha);
}
fixed4 NoLightingEffect_Modulate_PS (NoLightingEffect_v2f i)
{
	fixed4 color0 = tex2D(_MainTex, i.uv0);
    fixed4 color1 = tex2D(_MainTex1, i.uv1);
    
    return fixed4(color0.rgb * color1.rgb, color0.a * color1.a* _Alpha);
}
//fixed4 AlphaCut(NoLightingEffect_v2f i)
//{
//	fixed4 color0 = tex2D(_MainTex, i.uv0);
//	fixed4 color1 = tex2D(_MainTex1,i.uv1);
	
	
//}