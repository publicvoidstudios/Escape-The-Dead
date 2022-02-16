using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MeshCombiner))]
public class MeshCombinerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MeshCombiner combiner = (MeshCombiner)target;
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Box("NOTE: After pessing this button, all meshes, that are children to this GameObject will be converted in a single mesh. They will remain, but will all be set to inactive state.");
        GUILayout.FlexibleSpace();
        if(GUILayout.Button("GET ALL CHILDREN"))
        {
            combiner.GetAllChildren();
        }
        if(GUILayout.Button("PRECOMBINE MESHES"))
        {
            combiner.CM();
        }
        if(GUILayout.Button("REACTIVATE CHILDREN"))
        {
            combiner.ActivateAllChildren();
        }
        GUILayout.EndVertical();
    }
}
