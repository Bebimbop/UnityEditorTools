using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildPropertyWindow : EditorWindow
{
    private EditorWindow _instance;

    private string buildName;
    private bool copyFiles;

    private string changeLog;
    private Vector2 scrollPosition = Vector2.zero;

    private Dictionary<int, BuildTargetGroup> buildTargetGroupOptions = new Dictionary<int, BuildTargetGroup>()
    {

    };

    private string[] buildTargetOptions = new string[]
    {
        "StandAloneWindows", "StandAloneWindows64",
        "iOS", "Android"
    };

    private int selectedBuildTarget = 0;
    private int previousBuildTarget = 0;
    private BuildTargetGroup _buildTargetGroup;
    private BuildTarget _buildTarget;

    public static void ShowWindow()
    {
        EditorWindow.GetWindow<BuildPropertyWindow>().Show();
    }

    void OnEnable()
    {
        buildName = PlayerSettings.productName;
        copyFiles = true;
        buildName += "_" + DateTime.Now.ToString("MM-dd-yy_HHmm");
        changeLog = "Change Log";
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        buildName = EditorGUILayout.TextField("Build Name:", buildName);
        copyFiles = EditorGUILayout.Toggle("Include Config Files: ", copyFiles);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.Label("Change Log");
        EditorGUILayout.BeginHorizontal();
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, true, true, GUILayout.Width(500.0f), GUILayout.Height(200.0f));
        changeLog = EditorGUILayout.TextArea(".....", changeLog);
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndHorizontal();

        EditorUtility.SetDirty(this);

        GUILayout.BeginArea(new Rect(Screen.width/2.0f - 125.0f, Screen.height - 60.0f, 250, 25.0f));
        if (GUILayout.Button("Build", GUILayout.MaxWidth(250.0f), GUILayout.MaxHeight(25.0f)))
        {
            //AutoBuild.BuildProject(BuildOptions.ShowBuiltPlayer, buildName, addDateTime, copyFiles,
            //    EditorUserBuildSettings.selectedBuildTargetGroup,
            //    EditorUserBuildSettings.activeBuildTarget);
            AutoBuild.BuildProjectCustomSettings(BuildOptions.ShowBuiltPlayer, buildName, copyFiles);
        }
        GUILayout.EndArea();

        Repaint();
    }
}
