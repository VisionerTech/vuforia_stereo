Shader "Unlit/GraPass"
{
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
		_CellSize ("Cell Size", Vector) = (0.04, 0.04, 0, 0)
    }
    SubShader
    {
        Tags{"Queue"="Transparent"}
     
	    GrabPass { "_GrabTexture"}
       
        pass
        {
            Name "pass2"
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           
            #include "UnityCG.cginc"
            sampler2D _GrabTexture;
            float4 _GrabTexture_ST;
            struct v2f {
                float4  pos : SV_POSITION;
                float2  uv : TEXCOORD0;
				float4 grabUV : TEXCOORD1;
            } ;

			float4 _CellSize;

            v2f vert (appdata_base v)
            {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP,v.vertex);
                o.uv =  TRANSFORM_TEX(v.texcoord,_GrabTexture);
				o.grabUV = ComputeGrabScreenPos(o.pos);
                return o;
            }
            float4 frag (v2f i) : COLOR
            {
				float2 steppedUV = i.grabUV.xy/i.grabUV.w;
				//steppedUV /= _CellSize.xy;
                //steppedUV = round(steppedUV);
                //steppedUV *= _CellSize.xy;
                float2 offset = float2(0.65/960.0, 0.65/1080.0);
                steppedUV += offset;
                float4 texCol = tex2D(_GrabTexture,steppedUV);
                
                steppedUV -= offset*2.0;
                float4 texCol2 = tex2D(_GrabTexture,steppedUV);
                
                return (texCol+texCol2)/2.0;
            }
            ENDCG
        }
    }
}
