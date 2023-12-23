Shader "Custom/reversible" {

    Properties{
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _Alpha("Alpha",Range(0,1.0)) = 1.0
        _BackMainTex("Albedo (RGB)", 2D) = "white" {}
        Cutoff("Cutoff", Range(0,1)) = 0.5
    }



    SubShader{
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 200
        Cull Front

        CGPROGRAM


    #pragma surface surf Standard alpha:fade


    struct Input {

        float2 uv_MainTex;   
        float3 worldNormal;INTERNAL_DATA

    };


    half _Glossiness;

    half _Metallic;

    fixed4 _Color;

    uniform float _Alpha;

    sampler2D _MainTex;


    void surf(Input IN, inout SurfaceOutputStandard o) {

        fixed4 mainTex = tex2D(_MainTex, IN.uv_MainTex)*_Color;

        o.Albedo = mainTex.rgb;

        o.Normal =float3(0,0,-1);

        o.Alpha = mainTex.a*_Alpha;

    }

ENDCG


    Cull Back

    CGPROGRAM

    #pragma surface surf Standard alpha:fade
    #pragma target 3.0

    struct Input {

        float2 uv_MainTex;

    };


    half _Glossiness;

    half _Metallic;

    fixed4 _Color;

    uniform float _Alpha;

    sampler2D _BackMainTex;


    void surf(Input IN, inout SurfaceOutputStandard o) {

        fixed4 backmainTex = tex2D(_BackMainTex, IN.uv_MainTex)*_Color;

        o.Albedo = backmainTex.rgb;

        o.Alpha = backmainTex.a*_Alpha;

    }

ENDCG

}
FallBack "Transparent/Cutout/Diffuse"
}