Shader "Custom/VertexColor_Emission"
{
	Properties {
		_Color("_Color", Color) = (1,1,1,1)
		_MainTex("_MainTex", 2D) = "black" {}
		_Emission("_Emission", Color) = (1,1,1,1)
		_EmTex("_EmTex", 2D) = "black" {}
	}
	
SubShader {
	Pass{
        Material {
            Shininess [_Shininess]
            Specular [_SpecColor]
            //Emission [_Emission]
        }
        ColorMaterial AmbientAndDiffuse
        Lighting Off
        Fog { Mode Off }
        SetTexture [_MainTex] {
            Combine texture * primary, texture * primary
        }
        SetTexture [_MainTex] {
            constantColor [_Color]
            Combine previous * constant DOUBLE, previous * constant
        } 
	}
	
	Pass{
		Blend One One
		Material{
			//Diffuse [_Color]
			Emission [_Emission]
		}    
		ColorMaterial Emission
		Lighting Off
		Fog { Mode Off }
        SetTexture [_EmTex] {
          Combine texture
        }
        SetTexture[_EmTex]{
        	constantColor [_Emission]
        	Combine previous * constant DOUBLE
        	
        }
	}
}
Fallback " VertexLit",1
}