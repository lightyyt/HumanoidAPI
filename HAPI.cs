using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using UnityEngine;

namespace HumanoidAPI;

// ReSharper disable once InconsistentNaming
public static class HAPI
{
    internal static ManualLogSource Logger;
    internal static readonly Dictionary<string, string> Plugins = [];
    internal static readonly List<string> LoadedPlugins = [];
    internal static int UsesHapiCount;

    public static bool ForceMouseShow { get; private set; }
    
    /// <summary>
    /// Initialize your Plugin to show properly in the HumanoidAPI Mod List
    /// </summary>
    /// <param name="guid">Your Plugins GUID</param>
    /// <param name="compatibleVersion">HumanoidAPI Version your Plugin supports</param>
    public static void InitPlugin(string guid, string compatibleVersion)
    {
        //Add HapiPlugin
        Plugins.Add(guid, compatibleVersion);
        Logger.LogInfo($"Plugin with GUID {guid} added!");
        if (compatibleVersion != HumanoidAPIInfo.PluginVersion)
        {
            Logger.LogInfo($"Plugin Compatible Version does not match HumanoidAPI Version!");
            Logger.LogInfo($"Please update your Plugin or HumanoidAPI for Proper functionality!");
        }

        UpdatePluginList();
    }
    
    internal static void UpdatePluginList()
    {
        LoadedPlugins.Clear();
        UsesHapiCount = 0;

        //Loop through each Plugin
        for (int pluginID = 0; pluginID < Chainloader.PluginInfos.Count; pluginID++)
        {
            UsesHapiCount++;
            var plugin = Chainloader.PluginInfos.Keys.ToList()[pluginID]; //Get Plugin
            var info = Chainloader.PluginInfos[plugin];
            var meta = info.Metadata;
            
            //Hide Hapi from Plugin List
            if (meta.GUID == HumanoidAPIInfo.PluginGuid) continue;
            
            var infoText = $"<color=#FFFF7F><b>{meta.Name}</b></color>";
            
            Version version = meta.Version;
            infoText += $"({version} -> {meta.GUID})";
            
            //If not using HAPI
            if (!Plugins.ContainsKey(meta.GUID))
            {
                infoText += "<color=#FFa000> No H-API</color>";
                UsesHapiCount--; //Remove Plugin from HAPI Count
            }else if(Plugins[meta.GUID] != HumanoidAPIInfo.PluginVersion) //If HAPI Version not Matching
            {
                infoText += $"<color=#FF0000>HumanoidAPI Version Incorrect! ({Plugins[meta.GUID]} != {HumanoidAPIInfo.PluginVersion})</color>";
            }
            
            LoadedPlugins.Add(infoText);
        }
    }

    public static void SetMouseForce(bool value)
    {
        ForceMouseShow = value;
        Cursor.visible = value;
    }
}