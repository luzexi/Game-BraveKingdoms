

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class Exporter
{
    private const string DEFAULT_BUNDLE_ID = "com.jimei.bravekingdoms";

    [MenuItem("BKTool/Export/ios")]
    public static void ExportIOS()
    {
#if UNITY_IPHONE
        string exportPath = "../../export-ios/project";
        
        var args = System.Environment.GetCommandLineArgs();
        int index = Array.IndexOf(args, "-export");
        if (-1 != index)
        {
            exportPath = args[index + 1];
        }
        Debug.Log("##### ExportPath : " + exportPath);

        string symbols = "";
        index = Array.IndexOf(args, "-symbols");
        if (-1 != index)
        {
            symbols = args[index + 1];
        }
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iPhone, symbols);
        Debug.Log("##### symbols : " + symbols);

        var opt = BuildOptions.SymlinkLibraries;

//      var opt = BuildOptions.AcceptExternalModificationsToPlayer |
//          BuildOptions.SymlinkLibraries |
//          BuildOptions.Development |
//          BuildOptions.ConnectWithProfiler |
//          BuildOptions.AllowDebugging;
        
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.iPhone);
//      EditorUserBuildSettings.symlinkLibraries = true;
        EditorUserBuildSettings.development = true;
        PlayerSettings.bundleVersion = "1.0.0";
        PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK;
        PlayerSettings.bundleIdentifier = DEFAULT_BUNDLE_ID;
        PlayerSettings.statusBarHidden = true;
        BuildPipeline.BuildPlayer(GetScenes(),
                                  exportPath,
                                  BuildTarget.iPhone,
                                  opt);
#else
        Debug.LogError("Please switch pratform.");
#endif
    }

    // build scenes
    public static string[] GetScenes()
    {
        return new string[]{"Assets/Scenes/Game.unity"};
    }
}
