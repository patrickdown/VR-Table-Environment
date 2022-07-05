Shader "Custom/MaskZ" {
	SubShader{
		Tags { "RenderType" = "Opaque" "Queue" = "Geometry-1"}
		ColorMask 0
		ZWrite on
		Stencil {
			Ref 1
			Comp NotEqual
			Pass keep
		}

		CGINCLUDE
			struct appdata {
				float4 vertex : POSITION;
			};
			struct v2f {
				float4 pos : SV_POSITION;
			};
			v2f vert(appdata v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}
			half4 frag(v2f i) : SV_Target {
				return half4(1,1,1,1);
			}
		ENDCG
		Pass {
			Cull Back
			ZTest always

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}
	}
}