using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(AlphabetData))]
[CanEditMultipleObjects]
[System.Serializable]
public class AlphabetDataDrawer : Editor
{
    private ReorderableList AlphaBetPlainList;
    private ReorderableList AlphaBetNormalList;
    private ReorderableList AlphaBetHighlightedList;
    private ReorderableList AlphaBetWrongList;

    private void OnEnable()
    {
        InitailzeReorderableList(ref AlphaBetPlainList, "AlphaBetPlane", "Alphabet Plain");
        InitailzeReorderableList(ref AlphaBetNormalList, "AlphaBetNormal", "AlphaBet Normal List");
        InitailzeReorderableList(ref AlphaBetHighlightedList, "AlphaBetHighlighted", "Alphabet Highlighted List");
        InitailzeReorderableList(ref AlphaBetWrongList, "AlphaBetWrong", "Alphabet Wrong List");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        AlphaBetPlainList.DoLayoutList();
        AlphaBetNormalList.DoLayoutList();
        AlphaBetHighlightedList.DoLayoutList();
        AlphaBetWrongList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    private void InitailzeReorderableList(ref ReorderableList list, string propertyName, string listLabel)
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty(propertyName),
                true, true, true, true);
        list.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, listLabel);
        };

        var l = list;

        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = l.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),
                                    element.FindPropertyRelative("letter"), GUIContent.none);

            EditorGUI.PropertyField(new Rect(rect.x + 70, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight),
                                     element.FindPropertyRelative("image"), GUIContent.none);
        };
    }
}
