
Shader "Mobile/FX/Cracking Bumped Specular" {
Properties {
    _Shininess ("Shininess", Range (0.01, 1)) = 0.078125
    _MainTex ("Base", 2D) = "white" {}
    _BumpMap ("Normalmap", 2D) = "bump" {}
    _SecondTex ("Cracks (A)", 2D) = "white" {}
    _Color ("Cracks Color", Color) = (0.5, 0.5, 0.5, 1)
    _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}

SubShader {
    Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
    LOD 400

    CGPROGRAM
    #pragma surface surf BlinnPhong

    sampler2D _MainTex;
    sampler2D _BumpMap;
    half _Shininess;

    struct Input {
        float2 uv_MainTex;
        float2 uv_BumpMap;
    };

    void surf (Input IN, inout SurfaceOutput o) {
        fixed4 mainTex = tex2D(_MainTex, IN.uv_MainTex);
        o.Albedo = mainTex.rgb;
        o.Gloss = mainTex.a;
        o.Specular = _Shininess;
        o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
    }
    ENDCG


    // Add SecondTex on top with alpha cutoff
    CGPROGRAM
    #pragma surface surf BlinnPhong alphatest:_Cutoff

    sampler2D _SecondTex;
    float3 _Color;

    struct Input {
        float2 uv_SecondTex;
    };

    void surf (Input IN, inout SurfaceOutput o) {
        fixed4 c = tex2D(_SecondTex, IN.uv_SecondTex);
        o.Albedo = c.rgb * _Color;
        o.Alpha = c.a;
    }
    ENDCG
}

FallBack "Transparent/Cutout/VertexLit"
}
