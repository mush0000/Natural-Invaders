Shader "Custom/CubeReversible" {
    Properties {
        _Color("色", Color) = (1, 1, 1, 1)
        _MainTex("表面のテクスチャ", 2D) = "white" {}
        _Glossiness("滑らかさ", Range(0,1)) = 0.5
        _Metallic("メタリック", Range(0,1)) = 0.0
        _Alpha("アルファ", Range(0,1.0)) = 1.0
        _BackMainTex("裏面のテクスチャ", 2D) = "white" {}
        Cutoff("カットオフ", Range(0,1)) = 0.5
    }

    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 200
        Cull Front  // 前面のカリングを有効化

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
            fixed4 mainTex = tex2D(_MainTex, IN.uv_MainTex) * _Color;

            o.Albedo = mainTex.rgb;
            o.Normal = float3(0, 0, -1);  // 前面の法線を設定（カメラに向かっていると仮定）
            o.Alpha = mainTex.a * _Alpha;

            // 上下左右のレンダリングをオフにする
            if (abs(IN.worldNormal.y) > 0.5 || abs(IN.worldNormal.x) > 0.5)
                discard;
        ENDCG
    }

    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 200
        Cull Back  // 裏面のカリングを有効化

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
            fixed4 backMainTex = tex2D(_BackMainTex, IN.uv_MainTex) * _Color;

            o.Albedo = backMainTex.rgb;
            o.Alpha = backMainTex.a * _Alpha;

            // 上下左右のレンダリングをオフにする
            if (abs(IN.worldNormal.y) > 0.5 || abs(IN.worldNormal.x) > 0.5)
                discard;
        ENDCG
    }

    Fallback "Transparent/Cutout/Diffuse"
}
