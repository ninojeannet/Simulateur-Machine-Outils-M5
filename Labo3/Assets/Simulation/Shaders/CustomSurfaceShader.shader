Shader "Custom/CustomSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _CubeSize("Cube size", Int) = 128
        _MainTex ("Main Texture", 2D) = "white" {}
        _GlossinessFirst ("Smoothness ", Range(0,1)) = 0.5
        _MetallicFirst ("Metallic", Range(0,1)) = 0.0
		_SecondaryTex ("Secondary texture", 2D) = "white"{}
        _GlossinessSecond ("Smoothness ", Range(0,1)) = 0.5
        _MetallicSecond ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _SecondaryTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv2_SecondaryTex;
            float3 worldPos;
        };

        half _GlossinessFirst;
        half _MetallicFirst;
        half _GlossinessSecond;
        half _MetallicSecond;
        fixed4 _Color;
        int _CubeSize;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c;
            if (IN.worldPos[0] < 1.5 || IN.worldPos[1] < 1.5 || IN.worldPos[2] < 1.5 || IN.worldPos[0] > _CubeSize-0.5 || IN.worldPos[1] >= _CubeSize-0.5 || IN.worldPos[2] > _CubeSize-0.5)
            {
                c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                // Metallic and smoothness come from slider variables
                o.Metallic = _MetallicFirst;
                o.Smoothness = _GlossinessFirst;
                o.Alpha = c.a;
            }
            else
            {
                c = tex2D (_SecondaryTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                // Metallic and smoothness come from slider variables
                o.Metallic = _MetallicSecond;
                o.Smoothness = _GlossinessSecond;
                o.Alpha = c.a;
            }
            // Ici regarder en fonction de la position et afficher la texture en fonction de
            // garder les 2 memes uvs
            // https://docs.unity3d.com/Manual/SL-SurfaceShaders.html worldpos
            // Albedo comes from a texture tinted by color
            

        }
        ENDCG
    }
    FallBack "Diffuse"
}
