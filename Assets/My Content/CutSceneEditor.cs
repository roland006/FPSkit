using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CutScene))]
public class CutSceneEditor : Editor
{
    private CutScene _thisCutScene;

    void OnEnable()
    {
        _thisCutScene = (CutScene)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button(
            "Spawn Point"
        ))
        {
            _thisCutScene.SpawnPoint();
        }

        if (GUILayout.Button(
            "Update Points"
        ))
        {
            _thisCutScene.UpdatePoints();
        }

        if (GUILayout.Button(
            "Delete All Points"
        ))
        {
            _thisCutScene.DeleteAllPoints();
        }
    }
}

#endif