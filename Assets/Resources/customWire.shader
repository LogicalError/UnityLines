Shader "Custom/customWireLines" 
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
		ZTest LEqual
        Cull Off
		//Offset -1 -1 // why do I get a parser error here?
		Blend SrcAlpha OneMinusSrcAlpha

        Pass 
		{
			CGPROGRAM
				
				#pragma vertex vert
				#pragma fragment frag
			
				#include "UnityCG.cginc"

				struct v2f 
				{
 					float4 pos   : SV_POSITION;
 					fixed4 color : COLOR0;
				};

				v2f vert (appdata_full v)
				{
					v2f o;
					o.pos	= mul (UNITY_MATRIX_MVP, v.vertex);
					o.pos.z -= 0.0011f;	// I would use Offset if it actually worked ..
					o.color = v.color;
					return o;
				}

				fixed4 frag (v2f input) : SV_Target
				{
					return input.color;
				}

			ENDCG
		}
	}
}
