using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Moving))]
public class MovingEditor : Editor
{
    private SerializedProperty _speedMove;
    private SerializedProperty _speedRotate;
    private SerializedProperty _speedScale;

    private SerializedProperty _isMove;
    private SerializedProperty _isRotate;
    private SerializedProperty _isScale;

    private void OnEnable()
    {
        _speedMove = serializedObject.FindProperty("_speedMove");
        _speedRotate = serializedObject.FindProperty("_speedRotate");
        _speedScale = serializedObject.FindProperty("_speedScale");

        _isMove = serializedObject.FindProperty("_isMove");
        _isRotate = serializedObject.FindProperty("_isRotate");
        _isScale = serializedObject.FindProperty("_isScale");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(this._isMove);

        if (_isMove.boolValue)
            EditorGUILayout.PropertyField(this._speedMove);

        EditorGUILayout.PropertyField(this._isRotate);

        if (_isRotate.boolValue)
            EditorGUILayout.PropertyField(this._speedRotate);

        EditorGUILayout.PropertyField(this._isScale);

        if (_isScale.boolValue)
            EditorGUILayout.PropertyField(this._speedScale);

        serializedObject.ApplyModifiedProperties();
    }
}
