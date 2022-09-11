using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseMinotaurLogic),true)]
[CanEditMultipleObjects]
public class MinotaurMovementTest : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Move minotaur"))
        {
            FindObjectOfType<BaseMinotaurLogic>().MovementLogic();
        }
    }
}
