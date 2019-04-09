using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            MapGenerator mapGenerator = target as MapGenerator;
            mapGenerator.Generate();
        }

        if (GUILayout.Button("Clear"))
        {
            MapGenerator mapGenerator = target as MapGenerator;
            mapGenerator.Clear();
        }
    }
}
