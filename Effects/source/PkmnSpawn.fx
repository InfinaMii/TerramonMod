sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
float3 uColor;
float3 uSecondaryColor;
float uOpacity;
float uSaturation;
float uRotation;
float uTime;
float uIntensity;
float4 uSourceRect;
float2 uWorldPosition;
float uDirection;
float3 uLightSource;
float2 uImageSize0;
float2 uImageSize1;
float2 uTargetPosition;
float4 uLegacyArmorSourceRect;
float2 uLegacyArmorSheetSize;

float4 PokemonDespawn(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, coords);

    float origalpha = color.a;
    color.a = 1 - ((frac(uTime) - 0.2f) / 0.8f);
    color.a *= origalpha;

    float lightimer = (frac(uTime) / 0.2f);
    if (lightimer > 1)
        lightimer = 1;

    color.rgb += ((1 - color.rgb) * lightimer) * color.a;

    return color * sampleColor;
}

technique Technique1
{
    pass TerramonShaderPass
    {
        PixelShader = compile ps_2_0 PokemonDespawn();
    }
}