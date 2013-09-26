﻿Shader "Custom/AfineShader" {
Properties {
       _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader {
       Tags { "RenderType"="Opaque" }
       LOD 200
 
       Pass {
       CGPROGRAM
       #pragma vertex vert
       #pragma fragment frag
       #include "UnityCG.cginc"
 
       sampler2D _MainTex;
 
       struct vertexInput {
         float4 vertex : POSITION;
         float2 texcoord : TEXCOORD0;
       };
       struct vertexOutput {
         float4 pos : SV_POSITION;
         float3 normal;
         float2 uv : TEXCOORD0;
       };
 
       vertexOutput vert(vertexInput input) // vertex shader
       {
         vertexOutput output;
         output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
         output.normal = output.pos.xyz; // using normal because POSITION semantic isn't visible in fragment shader
         output.uv = input.texcoord * output.normal.z;
         return output;
       } 
 
       float4 frag(vertexOutput input) : COLOR // fragment shader
       {
         return tex2D(_MainTex, input.uv/input.normal.z);
       }
 
       ENDCG
       }
    } 
}