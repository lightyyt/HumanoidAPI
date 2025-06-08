using HarmonyLib;
using UnityEngine;

namespace HumanoidAPI.Patch;

[HarmonyPatch(typeof(MenuSystem), "BindCursor")]
class PatchMenuSystem
{
    static bool Prefix(MenuSystem __instance, ref bool force)
    {
        if (!HAPI.ForceMouseShow)
            return true;

        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (__instance.mouseBlocker != null)
            __instance.mouseBlocker.SetActive(false);

        return false; // Skip original BindCursor
    }

}