using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//skrypt nie jest dodawany do �adnego obiektu.
[CustomEditor(typeof(CardManager))]
public class CardManagerEditor : Editor
{
     //Skrypt umo�liwia edytowanie wysoko�ci i szeroko�ci dzi�ki czemu zmiena si� _pairAmount + error w inspektorze gdy dajemy za du�� wysoko�� i szeroko�� (mamy tylko 10kart) wi�c nie mo�e by� wi�cej ni� 10 _pairAmount 

    SerializedObject manager;
    SerializedProperty _pairAmount;
    SerializedProperty _height;
    SerializedProperty _width;
    SerializedProperty _spriteList;

    int spriteAmount;
    float w, h;

    private void OnEnable()
    {
        manager = new SerializedObject(target);
        _pairAmount = manager.FindProperty("pairAmount");
        _height = manager.FindProperty("height");
        _width = manager.FindProperty("width");
        _spriteList = manager.FindProperty("spriteList");
        spriteAmount = _spriteList.arraySize;
    }

    //nadpisuje inspector
    public override void OnInspectorGUI()
    {
        manager.Update();

        EditorGUILayout.BeginVertical(GUI.skin.box);
        GUI.enabled = false;
        EditorGUILayout.PropertyField(_pairAmount);
        GUI.enabled = true;
        EditorGUILayout.PropertyField(_width);
        EditorGUILayout.PropertyField(_height);

        float temporary = _width.intValue * (float)_height.intValue / 2;
        _pairAmount.intValue = (int)System.Math.Ceiling(temporary);

        if (_pairAmount.intValue > spriteAmount)
        {
            EditorGUILayout.HelpBox("To much Card Pairs", MessageType.Error);
        }

        //te dwa warunki sprawiaj�, �e szeroko�� i wysoko�� nie mog� by� ujemne
        if (_width.intValue < 0)
        {
            _width.intValue = 0;
        }
        if (_height.intValue < 0)
        {
            _height.intValue = 0;
        }

        EditorGUILayout.EndVertical();

        manager.ApplyModifiedProperties();
        DrawDefaultInspector();
    }
}
