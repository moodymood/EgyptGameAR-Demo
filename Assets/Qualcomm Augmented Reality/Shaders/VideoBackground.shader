//Copyright (c) 2014 Qualcomm Connected Experiences, Inc.
//All Rights Reserved.
//Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
Shader "Custom/VideoBackground" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader {
    	//"queue"="geometry-11"
        Tags {"Queue"="Geometry" "RenderType"="opaque" }
        Pass {
            ZWrite Off
            Cull Off
            Lighting Off
            
            SetTexture [_MainTex] {
                combine texture 
            }
        }
    } 
    FallBack "Diffuse"
}
