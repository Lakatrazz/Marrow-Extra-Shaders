using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

public static partial class ShaderConverter {
    private static void ConvertForceField(Material material) {
        material.shader = Shader.Find("Universal Render Pipeline/Shader Forge/Force Field");
    }

    private static void ConvertTVScreen(Material material) {
        material.shader = Shader.Find("Universal Render Pipeline/Shader Forge/TVScreen");
    }

    private static void ConvertParallaxBG(Material material) {
        material.shader = Shader.Find("Universal Render Pipeline/SLZ/ParallaxBG");
    }

    private static void ConvertSkybox(Material material) {
        material.shader = Shader.Find("Skybox/6 Sided");
    }

    private static void ConvertLightCone(Material material) {
        material.shader = Shader.Find("Universal Render Pipeline/Shader Forge/lightcone");
    }

    private static void ConvertValveSilhouette(Material material) {
        material.shader = Shader.Find("Universal Render Pipeline/Valve/vr_silhouette");
    }

    private static void ConvertValveVR(Material material) {
        material.shader = Shader.Find("Universal Render Pipeline/Valve/vr_standard");
        UpdateValveVRSpecular(material);
    }

    private static void UpdateValveVRSpecular(Material material) {
        var specularMode = Mathf.RoundToInt(material.GetFloat("_SpecularMode"));

        float workflowMode;
        bool isSpecular;

        switch (specularMode) {
            // BlinnPhong
            case 0:
                workflowMode = 0f;
                isSpecular = true;
                break;
            // Metallic
            case 1:
            // Anisotropic
            case 2:
            // Retroreflective
            case 3:
            default:
                workflowMode = 1f;
                isSpecular = false;
                break;
        }


        material.SetFloat("_WorkflowMode", workflowMode);

        if (isSpecular) {
            material.EnableKeyword("_METALLICSPECGLOSSMAP");
            material.EnableKeyword("_SPECULAR_SETUP");
        }
        else {
            material.DisableKeyword("_METALLICSPECGLOSSMAP");
            material.DisableKeyword("_SPECULAR_SETUP");
        }
    }
}
