using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//skrypt nie jest dodawany do ¿adnego obiektu.
[CustomEditor(typeof(CardManager))]
public class CardManagerEditor : Editor
{
     //Skrypt umo¿liwia edytowanie wysokoœci i szerokoœci dziêki czemu zmiena siê _pairAmount + error w inspektorze gdy dajemy za du¿¹ wysokoœæ i szerokoœæ (mamy tylko 10kart) wiêc nie mo¿e byæ wiêcej ni¿ 10 _pairAmount 

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

        //te dwa warunki sprawiaj¹, ¿e szerokoœæ i wysokoœæ nie mog¹ byæ ujemne
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
