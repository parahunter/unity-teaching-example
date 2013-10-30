Shader "Birke/UnlitTransparent" 
{
	Properties 
	{
	    _Color ("Main Color", Color) = (1,1,1,0.5)
	    _MainTex ("Texture", 2D) = "white" { }
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
						
			v2f_img vert (appdata_img v)
			{
			    v2f_img o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    o.uv = v.texcoord;
			    return o;
			}
			
			half4 frag (v2f_img i) : COLOR
			{
				
				half4 col = tex2D(_MainTex, i.uv);
				
				return col * _Color;
			}
			ENDCG
	
	    }
	}
	Fallback "VertexLit"
} 