using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelEditorWindow : EditorWindow
{
    private LevelData levelData;

    [MenuItem("Tools/Level Editor")]
    public static void OpenWindow()
    {
        GetWindow<LevelEditorWindow>("Level Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Level Editor", EditorStyles.boldLabel);

        levelData = (LevelData)EditorGUILayout.ObjectField("Level Data", levelData, typeof(LevelData), false);

        if (levelData != null)
        {
            levelData.levelName = EditorGUILayout.TextField("Level Name", levelData.levelName);

            SerializedObject serializedObject = new SerializedObject(levelData);
            SerializedProperty wordsProperty = serializedObject.FindProperty("words");
            EditorGUILayout.PropertyField(wordsProperty, true);
            serializedObject.ApplyModifiedProperties();

            levelData.actionAnimation = (AnimationClip)EditorGUILayout.ObjectField("Action Animation", levelData.actionAnimation, typeof(AnimationClip), false);

            if (GUILayout.Button("Save Level"))
            {
                EditorUtility.SetDirty(levelData);
                AssetDatabase.SaveAssets();
            }
        }
    }
}

