Shader "Vegetation" {
    Properties {
        _Color ("Main Color", Color) = (.5, .5, .5, .5)
        _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
        _Cutoff ("Base Alpha cutoff", Range (0,.9)) = .5
    }
    SubShader {
        // Set up basic lighting
  // 设置基础光照
        Material {
            Diffuse [_Color]
            Ambient [_Color]
        }
        Lighting On
        // Render both front and back facing polygons.
  //渲染几何体的两面
        Cull Off
        // first pass:
        //   render any pixels that are more than [_Cutoff] opaque
  //第一步 渲染所有超过[_Cutoff] 不透明的像素
        Pass {
            AlphaTest Greater [_Cutoff]
            SetTexture [_MainTex] {
                combine texture * primary, texture
            }
        }
        // Second pass:
        //   render in the semitransparent details.
  // 第二步 渲染半透明的细节
        Pass {
            // Dont write to the depth buffer
   // 不写到深度缓冲
            ZWrite off
            // Don't write pixels we have already written.
   // 不写已经写过的像素
            ZTest Less
            // Only render pixels less or equal to the value
   // 只渲染少于或等于的像素值
            AlphaTest LEqual [_Cutoff]
            // Set up alpha blending
   // 设置透明度混合
            Blend SrcAlpha OneMinusSrcAlpha
            SetTexture [_MainTex] {
                combine texture * primary, texture
            }
        }
    }
}
