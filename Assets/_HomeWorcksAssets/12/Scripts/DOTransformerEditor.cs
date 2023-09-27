using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DOTransformer))]
public class DOTransformerEditor : Editor
{
    private SerializedProperty _isMove;
    private SerializedProperty _isRotate;
    private SerializedProperty _isScale;
    private SerializedProperty _isColor;

    private SerializedProperty _targetMove;
    private SerializedProperty _targetRotation;
    private SerializedProperty _targetScale;
    private SerializedProperty _targeColor;

    private SerializedProperty _timeMove;
    private SerializedProperty _timeRotate;
    private SerializedProperty _timeScale;
    private SerializedProperty _timeColor;


    private void OnEnable()
    {
        _isMove = serializedObject.FindProperty("_isMove");
        _isRotate = serializedObject.FindProperty("_isRotate");
        _isScale = serializedObject.FindProperty("_isScale");
        _isColor = serializedObject.FindProperty("_isColor");

        _targetMove = serializedObject.FindProperty("_targetMove");
        _targetRotation = serializedObject.FindProperty("_targetRotation");
        _targetScale = serializedObject.FindProperty("_targetScale");
        _targeColor = serializedObject.FindProperty("_targeColor");

        _timeMove = serializedObject.FindProperty("_timeMove");
        _timeRotate = serializedObject.FindProperty("_timeRotate");
        _timeScale = serializedObject.FindProperty("_timeScale");
        _timeColor = serializedObject.FindProperty("_timeColor");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(this._isMove);

        if (_isMove.boolValue)
        {
            EditorGUILayout.PropertyField(this._targetMove);
            EditorGUILayout.PropertyField(this._timeMove);
        }

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(this._isRotate);

        if (_isRotate.boolValue)
        {
            EditorGUILayout.PropertyField(this._targetRotation);
            EditorGUILayout.PropertyField(this._timeRotate);
        }

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(this._isScale);

        if (_isScale.boolValue)
        {
            EditorGUILayout.PropertyField(this._targetScale);
            EditorGUILayout.PropertyField(this._timeScale);
        }

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(this._isColor);

        if (_isColor.boolValue)
        {
            EditorGUILayout.PropertyField(this._targeColor);
            EditorGUILayout.PropertyField(this._timeColor);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
