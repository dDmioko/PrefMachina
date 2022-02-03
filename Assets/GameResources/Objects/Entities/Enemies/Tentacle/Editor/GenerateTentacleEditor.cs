using UnityEngine;
using UnityEditor;

/// <summary>
/// Editor for GenerateTentacle
/// </summary>
[CustomEditor(typeof(GenerateTentacle))]
public class GenerateTentacleEditor : Editor
{
    GenerateTentacle generateTentacle = null;

    private void Awake()
    {
        generateTentacle = target as GenerateTentacle;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            generateTentacle.Generate();
        }
    }
}