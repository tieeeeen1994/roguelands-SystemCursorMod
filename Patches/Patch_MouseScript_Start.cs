using HarmonyLib;
using GadgetCore.API;
using UnityEngine;

namespace SystemCursorMod.Patches // You may create multiple files like this. Use the prefix, the postfix, or both. You can also use a Transpiler if you wish.
{
    [HarmonyPatch(typeof(MouseScript))]
    [HarmonyPatch("Start")]
    [HarmonyGadget("SystemCursorMod")]
    public static class Patch_MouseScript_Start
    {

        [HarmonyPrefix]
        public static bool Prefix(MouseScript __instance)
        {
            // Add code to run before `MethodName` is called.
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            SystemCursorMod.GetLogger().Log("IT WENT HERE!!!!");
            return false; // Return false to prevent the vanilla method from running.
        }

        //[HarmonyPostfix]
        //public static void Postfix(ClassName __instance)
        //{
        //    // Add code to run after `MethodName` is called.
        //}
    }
}
