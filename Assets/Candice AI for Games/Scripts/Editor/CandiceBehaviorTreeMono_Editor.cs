using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
namespace CandiceAIforGames.AI.Editors
{
    [CustomEditor(typeof(CandiceBehaviorTreeMono))]
    public class CandiceBehaviorTreeMono_Editor : Editor
    {

        private CandiceBehaviorTreeMono character;
        private SerializedObject soTarget;
        private SerializedProperty soBehaviorTree;

       
        GUIStyle guiStyle = new GUIStyle();
        
        void OnEnable()
        {
            //Store a reference to the AI Controller script
            character = (CandiceBehaviorTreeMono)target;
            soTarget = new SerializedObject(character);
            soBehaviorTree = soTarget.FindProperty("behaviorTree");
            guiStyle.fontSize = 14;
            guiStyle.fontStyle = FontStyle.Bold;


        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            GUIStyle style = new GUIStyle();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            style.normal.textColor = Color.red;
            Texture2D image = (Texture2D)Resources.Load("CandiceLogo");
            GUIContent label = new GUIContent(image);
            GUILayout.Label(label);

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            label = new GUIContent("Candice Behavior Tree Mono");
            guiStyle.normal.textColor = EditorStyles.label.normal.textColor;
            GUILayout.Label(label, guiStyle);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.Space(6);
            EditorGUI.BeginChangeCheck();

            //tabIndex = GUILayout.Toolbar(tabIndex, arrTabs);



            if (EditorGUI.EndChangeCheck())
            {
                GUI.FocusControl(null);
            }
            GUILayout.Space(8);
            GUILayout.BeginVertical("box");
            EditorGUI.BeginChangeCheck();
            GUILayout.Label("Selected Behavior Tree", guiStyle);

            label = new GUIContent("Selected Behavior Tree", "The behavior tree the agent will use.");
            character.SelectedBehaviorTree = (SelectedBehaviorTree)EditorGUILayout.EnumPopup(label, character.SelectedBehaviorTree);

            if (EditorGUI.EndChangeCheck())
            {

            }

            GUILayout.EndVertical();

        }


       
    }
}