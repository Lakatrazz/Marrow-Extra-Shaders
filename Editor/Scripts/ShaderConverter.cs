using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

public static partial class ShaderConverter
{
    [MenuItem("CONTEXT/Material/Convert Shader/To Specular")]
    public static void ConvertToSpecular(MenuCommand command) {
        Convert(command, true);
    }

    [MenuItem("CONTEXT/Material/Convert Shader/To Metallic")]
    public static void ConvertToMetallic(MenuCommand command) {
        Convert(command, false);
    }

    private static void Convert(MenuCommand command, bool isSpecular) {
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
                ConvertValveVR(material, isSpecular);
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
