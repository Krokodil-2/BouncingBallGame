using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BouncingBall
{

    [CustomEditor(typeof(TowerBuilder))]
    public class TowerBuilderEditor : Editor
    {
        private TowerBuilder logic;

        SerializedProperty cellsBase;
        SerializedProperty cellPrefab_1;
        SerializedProperty cellPrefab_05;
        SerializedProperty cellPrefab_025;

        SerializedProperty tower;

        private GUIStyle labelTitle;
        private GUIStyle labelWarning;

        void OnEnable()
        {
            cellsBase = serializedObject.FindProperty("cellsBase");
            cellPrefab_1 = serializedObject.FindProperty("cell_1m_Prefab");
            cellPrefab_05 = serializedObject.FindProperty("cell_05m_Prefab");
            cellPrefab_025 = serializedObject.FindProperty("cell_025m_Prefab");

            tower = serializedObject.FindProperty("myBase");

        }
        public override void OnInspectorGUI()
        {
            #region GUIStyles

            labelTitle = new GUIStyle(GUI.skin.label);
            labelTitle.normal.textColor = Color.white;
            labelTitle.fontStyle = FontStyle.Bold;
            labelTitle.fontSize = 14;

            labelWarning = new GUIStyle(GUI.skin.label);
            labelWarning.normal.textColor = Color.red;
            labelWarning.fontStyle = FontStyle.Italic;
            labelWarning.fontSize = 12;

            var customButton = new GUIStyle(GUI.skin.button);
            customButton.normal.textColor = Color.white;
            customButton.fontStyle = FontStyle.Normal;
            customButton.fixedHeight = 20;
            customButton.fixedWidth = 150;

            var styleNameBuild = new GUIStyle(GUI.skin.label);
            styleNameBuild.normal.textColor = Color.white;
            styleNameBuild.fontStyle = FontStyle.Bold;
            styleNameBuild.fontSize = 14;
            styleNameBuild.wordWrap = true;

            var styleBuildButton = new GUIStyle(GUI.skin.button);
            styleBuildButton.normal.textColor = Color.white;
            styleBuildButton.fontStyle = FontStyle.Bold;
            styleBuildButton.fontSize = 12;
            styleBuildButton.fixedHeight = 30;
            styleBuildButton.fixedWidth = 150;
            #endregion

            #region Begin
            logic = (TowerBuilder)target;
            //base.OnInspectorGUI();
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            #endregion



            GUILayout.Label("Prefabs", labelTitle);
            EditorGUILayout.PropertyField(cellsBase);
            EditorGUILayout.PropertyField(cellPrefab_1);
            EditorGUILayout.PropertyField(cellPrefab_05);
            EditorGUILayout.PropertyField(cellPrefab_025);





            GUILayout.Space(20);
            GUILayout.Label("General CellBase Setup", labelTitle);
            EditorGUILayout.PropertyField(tower);

            if (!logic.TowerCreated)
            {
                if (GUILayout.Button("Create", customButton))
                {
                    logic.BuildTowerBase();
                }
            }
            else
            {
                GUILayout.Label("Base Already Created", labelWarning);

            }


            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("AddCell 1m", customButton))
            {
                logic.AddCell(TowerCellType.One);
            }
            if (GUILayout.Button("AddCell 0.5m", customButton))
            {
                logic.AddCell(TowerCellType.ZeroFive);
            }
            if (GUILayout.Button("AddCell 0.25m", customButton))
            {
                logic.AddCell(TowerCellType.ZeroTwentyFive);
            }

            EditorGUILayout.EndHorizontal();
           






            if (EditorGUI.EndChangeCheck() )
            {

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}