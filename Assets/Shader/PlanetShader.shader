// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "KEK/PlanetShader"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Metallic("Metallic", Range( 0 , 1)) = 0
		_Roughness("Roughness", Range( 0 , 1)) = 0
		_VertexOffset("VertexOffset", Range( 0 , 0.1)) = 0
		_Opacity("Opacity", 2D) = "white" {}
		_Albedo("Albedo", Color) = (0,0,0,0)
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float2 texcoord_0;
		};

		uniform float4 _Albedo;
		uniform float _Metallic;
		uniform float _Roughness;
		uniform sampler2D _Opacity;
		uniform float _VertexOffset;
		uniform float _Cutoff = 0.5;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			o.texcoord_0.xy = v.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
			float3 ase_vertexNormal = v.normal.xyz;
			float clampResult9 = clamp( _SinTime.w , -1.0 , 1.0 );
			v.vertex.xyz += ( ase_vertexNormal * (0.0 + (clampResult9 - -1.0) * (_VertexOffset - 0.0) / (1.0 - -1.0)) );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 temp_output_44_0 = _Albedo;
			o.Albedo = temp_output_44_0.rgb;
			o.Emission = temp_output_44_0.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Roughness;
			o.Alpha = 1;
			float clampResult36 = clamp( _SinTime.w , -1.0 , 1.0 );
			clip( tex2D( _Opacity, ( ( (float2( -0.5,-0.5 ) + (i.texcoord_0 - float2( 0,0 )) * (float2( 0.5,0.5 ) - float2( -0.5,-0.5 )) / (float2( 1,1 ) - float2( 0,0 ))) * (0.2 + (clampResult36 - -1.0) * (2.0 - 0.2) / (1.0 - -1.0)) ) + float2( 0.5,0.5 ) ) ).r - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13701
7;29;1906;1004;609.5723;339.4058;1;True;True
Node;AmplifyShaderEditor.SinTimeNode;35;-1588.42,503.1129;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ClampOpNode;36;-1410.42,505.1129;Float;False;3;0;FLOAT;0.0;False;1;FLOAT;-1.0;False;2;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.TextureCoordinatesNode;14;-1566.076,-18.7238;Float;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SinTimeNode;5;5,620;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.TFHCRemapNode;15;-1286.932,176.2175;Float;True;5;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT2;1,1;False;3;FLOAT2;-0.5,-0.5;False;4;FLOAT2;0.5,0.5;False;1;FLOAT2
Node;AmplifyShaderEditor.TFHCRemapNode;38;-1232.42,464.9129;Float;False;5;0;FLOAT;0.0;False;1;FLOAT;-1.0;False;2;FLOAT;1.0;False;3;FLOAT;0.2;False;4;FLOAT;2.0;False;1;FLOAT
Node;AmplifyShaderEditor.ClampOpNode;9;183,622;Float;False;3;0;FLOAT;0.0;False;1;FLOAT;-1.0;False;2;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;13;136,771;Float;False;Property;_VertexOffset;VertexOffset;3;0;0;0;0.1;0;1;FLOAT
Node;AmplifyShaderEditor.Vector2Node;33;-939.73,479.8319;Float;False;Constant;_Vector0;Vector 0;6;0;0.5,0.5;0;3;FLOAT2;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-921.208,200.1214;Float;True;2;2;0;FLOAT2;0,0;False;1;FLOAT;1,1;False;1;FLOAT2
Node;AmplifyShaderEditor.NormalVertexDataNode;3;66,435;Float;False;0;5;FLOAT3;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;32;-687.8308,311.9323;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2
Node;AmplifyShaderEditor.TFHCRemapNode;8;361,585;Float;False;5;0;FLOAT;0.0;False;1;FLOAT;-1.0;False;2;FLOAT;1.0;False;3;FLOAT;0.0;False;4;FLOAT;0.1;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;11;243,202;Float;False;Property;_Metallic;Metallic;1;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;44;201.8289,-46.58729;Float;False;Property;_Albedo;Albedo;5;0;0,0,0,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;385,426;Float;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0.0,0,0;False;1;FLOAT3
Node;AmplifyShaderEditor.SamplerNode;21;-330.3471,265.1104;Float;True;Property;_Opacity;Opacity;4;0;None;True;0;False;white;LockedToTexture2D;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;12;250,280;Float;False;Property;_Roughness;Roughness;2;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;668,86;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;KEK/PlanetShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Custom;0.5;True;True;0;True;TransparentCutout;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;0;0;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;FLOAT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;36;0;35;4
WireConnection;15;0;14;0
WireConnection;38;0;36;0
WireConnection;9;0;5;4
WireConnection;16;0;15;0
WireConnection;16;1;38;0
WireConnection;32;0;16;0
WireConnection;32;1;33;0
WireConnection;8;0;9;0
WireConnection;8;4;13;0
WireConnection;4;0;3;0
WireConnection;4;1;8;0
WireConnection;21;1;32;0
WireConnection;0;0;44;0
WireConnection;0;2;44;0
WireConnection;0;3;11;0
WireConnection;0;4;12;0
WireConnection;0;10;21;1
WireConnection;0;11;4;0
ASEEND*/
//CHKSM=9CDD0E88EF661FEF0420ADF17C2975A41EB0614C