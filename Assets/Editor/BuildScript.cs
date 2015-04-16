using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BuildScript 
{
    private static readonly string _versionNumber;
    private static readonly string _buildNumber;

    static BuildScript()
    {
        _versionNumber = Environment.GetEnvironmentVariable("VERSION_NUMBER");
        if (string.IsNullOrEmpty(_versionNumber))
            _versionNumber = "1.0.0.0";

        _buildNumber = Environment.GetEnvironmentVariable("BUILD_NUMBER");
        if (string.IsNullOrEmpty(_buildNumber))
            _buildNumber = "1";

        PlayerSettings.productName = "Your game name";
        PlayerSettings.bundleVersion =
            PlayerSettings.shortBundleVersion = _versionNumber;
    }

    static string[] GetScenes()
    {
        return EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
    }

    static void CheckDir(string dir)
    {
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
    }

    static void iOS()
    {
        CheckDir("Scratch/Xcode");
        PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.Mono2x, BuildTargetGroup.iPhone);
        PlayerSettings.SetPropertyInt("Architecture", (int)iPhoneArchitecture.ARMv7, BuildTargetGroup.iPhone);
        BuildPipeline.BuildPlayer(GetScenes(), "Scratch/Xcode", BuildTarget.iPhone, BuildOptions.None);
    }

    static void iOS64()
    {
        CheckDir("Scratch/Xcode");
        PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.IL2CPP, BuildTargetGroup.iPhone);
        PlayerSettings.SetPropertyInt("Architecture", (int)iPhoneArchitecture.Universal, BuildTargetGroup.iPhone);
        BuildPipeline.BuildPlayer(GetScenes(), "Scratch/Xcode", BuildTarget.iPhone, BuildOptions.None);
    }
}
