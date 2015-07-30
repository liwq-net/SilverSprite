//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- ColorToneEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

float4 Color : register(C2);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 scnColor = Color * tex2D(implicitInputSampler, uv);
    scnColor.r = lerp(0, scnColor.a, scnColor.r);
    scnColor.g = lerp(0, scnColor.a, scnColor.g);
    scnColor.b = lerp(0, scnColor.a, scnColor.b);
    return scnColor;
}


