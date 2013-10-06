Shader "Birke/TwirlShader" 
{
	Properties 
	{
	    _Color ("Main Color", Color) = (1,1,1,0.5)
	    _MainTex ("Texture", 2D) = "white" { }
	    _strengh ("Strengh", Float) = 0
	    _twirliness ("Twirliness", Range(5, 0)) = 0
	}
	SubShader 
	{
		Tags { "Queue" = "Transparent" }
	    Pass 
	    {  
	    	Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
						
			float4 _Color;
			sampler2D _MainTex;
			half _strengh;
			half _twirliness;		
						
			v2f_img vert (appdata_img v)
			{
			    v2f_img o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    o.uv = v.texcoord;
			    return o;
			}
			
			half4 frag (v2f_img i) : COLOR
			{
				half2 coordinates = i.uv - 0.5;
				half angle = atan2(coordinates.y, coordinates.x);
				half radius = length(coordinates);
				angle += radius * _strengh * _twirliness;
				
				half2 shifted = radius * half2(cos(angle), sin(angle));
				 
				half4 col = tex2D(_MainTex, shifted  + 0.5);
				
				// base alpha on how far we are from the center
				half alpha = radius * 2;
				
				//this adjusts the amount of alpha based on distance to center based on the twirliness 
				alpha = lerp(1, 0, alpha * _twirliness);
				//this makes sure the shader goes completely transparent when the twirl is at max
				alpha = lerp(alpha, 0, _twirliness * 0.2);
				
												
				col.a = alpha;
				return col;
			}
			ENDCG
	
	    }
	}
	Fallback "VertexLit"
} 