using TMPro;
using UnityEngine;

namespace HumanoidAPI.Internal;

internal static class UIHijack
{
    internal static string ModListText = "";
    internal static void VersionNumber()
    {
        var ver = GameObject.Find("Game(Clone)/Menu/MenuSystem/MainMenuWithMultiplayer(Clone)/VersionNumber");
        var version = ver.GetComponent<TMP_Text>();
        if (!version.text.Contains("HumanoidAPI"))
        {
            version.text = string.Format("<color=green>HumanoidAPI {0}</color>\n({1} plugins loaded. {2} w. HumanoidAPI)\n{3}</color>",
                HumanoidAPIInfo.PluginVersion,
                HAPI.LoadedPlugins.Count,
                HAPI.UsesHapiCount,
                version.text);
        }
    }

    internal static void TutorialLogButton()
    {
        var logButtonText = GameObject.Find("Game(Clone)/Menu/MenuSystem/ExtrasMenu(Clone)/MenuPanel/Buttons/LogButton/TextMeshPro Text");
        var tutorialLog = GameObject.Find("Game(Clone)/Menu/MenuSystem/TutorialLogMenu(Clone)/MenuPanel/Title");
        
        logButtonText.GetComponent<TMP_Text>().text = "<color=#444404>Plugins</color>";
        tutorialLog.GetComponent<TMP_Text>().text = "<color=#444404>Plugins</color>";
        HAPI.UpdatePluginList(); //Just in case a mod was missed
        
        foreach (string plugin in HAPI.LoadedPlugins)
        {
            ModListText += plugin + "\n";
        }
        
    }

    internal static void TutorialLog()
    {
        GameObject tutorialLog = GameObject.Find("Game(Clone)/Menu/MenuSystem/TutorialLogMenu(Clone)/NormalLayout/TextArea");
        tutorialLog.GetComponent<TMP_Text>().text = ModListText;
    }
}