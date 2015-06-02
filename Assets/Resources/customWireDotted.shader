Shader "Custom/customWireDottedLines" 
{
	Properties 
	{
	}
	SubShader 
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 200
        Lighting Off
        ZWrite Off
		ZTest Always
        Cull Off
		Blend SrcAlpha OneMinusSrcAlpha

        Pass 
		{
			CGPROGRAM
				
				#pragma vertex vert
				#pragma fragment frag
			
				#include "UnityCG.cginc"

				struct v2f 
				{
 					float4 pos			: SV_POSITION;
					half4  screenpos0   : TEXCOORD0;
					half4  screenpos1	: TEXCOORD1;
					float  dotSize		: TEXCOORD2;
					fixed4 color		: COLOR0;
				};

				v2f vert (appdata_full v)
				{
					v2f o;
					o.pos			= mul (UNITY_MATRIX_MVP, v.vertex);
					o.screenpos0	= half4(ComputeScreenPos ( o.pos));
					float4 pos2 = mul(UNITY_MATRIX_MVP, float4(v.texcoord.xyz, 1));
					o.screenpos1	= half4(ComputeScreenPos ( pos2 ));
					o.dotSize		= v.texcoord1.x;
					o.color			= v.color;
					return o;
				}

				fixed4 frag (v2f input) : SV_Target
				{
					half2	pos0			= input.screenpos0.xy;
					half2	rasterPosition0	= (pos0 * _ScreenParams.xy) / (input.dotSize * input.screenpos0.w);
					half2	pos1			= input.screenpos1.xy;
					half2	rasterPosition1	= (pos1 * _ScreenParams.xy) / (input.dotSize * input.screenpos1.w);
					half2  div				= abs(rasterPosition1 - rasterPosition0);
					
					half	value			= (div.x > div.y) ? rasterPosition0.x : rasterPosition0.y;

					half	f2				= step( frac(value), 0.5f);
					half	dist			= frac(f2 * 0.5f) * 2.0f;

					return fixed4(dist, dist, dist, dist) * input.color;
				}

			ENDCG
		}
	}
}
