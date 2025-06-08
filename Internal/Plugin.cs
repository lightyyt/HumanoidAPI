using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace HumanoidAPI.Internal;

[BepInPlugin(HumanoidAPIInfo.PluginGuid, HumanoidAPIInfo.PluginName, HumanoidAPIInfo.PluginVersion)]
internal class Plugin : BaseUnityPlugin
{
    internal new static ManualLogSource Logger;
    private void Awake()
    {
        // Plugin startup
        Logger = base.Logger;
        HAPI.Logger = Logger;
        Logger.LogInfo($"Plugin {HumanoidAPIInfo.PluginGuid} is loaded!");

        new Harmony(HumanoidAPIInfo.PluginGuid).PatchAll();
    }

    private void Start()
    {
        UIHijack.TutorialLogButton();
    }

    private void Update()
    {
        try
        {
            UIHijack.VersionNumber();
            UIHijack.TutorialLog();
            
            Setup.SetupLocalHuman();
            Setup.SetupGameElements();
            Setup.SetupOnlineHumans();
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
            //Ignore Errors
        }
    }

    
}