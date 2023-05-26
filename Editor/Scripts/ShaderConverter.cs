using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

public static partial class ShaderConverter
{
    [MenuItem("CONTEXT/Material/Marrow Extra Shaders/Update Specular Mode")]
    public static void UpdateSpecularMode(MenuCommand command) {
        var material = command.context as Material;

        Undo.RecordObject(material, "Update Specular Mode");

        switch (material.shader.name)
        {
            default:
                break;
            case "Universal Render Pipeline/Valve/vr_standard":
                UpdateValveVRSpecular(material);
                break;
        }
    }

    [MenuItem("CONTEXT/Material/Marrow Extra Shaders/Convert Shader")]
    private static void ConvertShader(MenuCommand command) {
        var material = command.context as Material;

        Undo.RecordObject(material, "Convert Shader");

        switch (material.shader.name) {
            default:
                break;
            case "Forge3D/Force Field":
                ConvertForceField(material);
                break;
            case "Shader Forge/TVScreen":
                ConvertTVScreen(material);
                break;
            case "SLZ/ParallaxBG":
                ConvertParallaxBG(material);
                break;
            case "Valve/vr_skybox":
                ConvertSkybox(material);
                break;
            case "Valve/vr_standard":
            case "Valve/vr_standard_Fluorescence":
            case "Valve/vr_standard_nosheen":
            case "Standard":
                ConvertValveVR(material);
                break;
            case "Valve/VR/Silhouette":
                ConvertValveSilhouette(material);
                break;
            case "Shader Forge/lightcone":
                ConvertLightCone(material);
                break;
        }
    }
}
