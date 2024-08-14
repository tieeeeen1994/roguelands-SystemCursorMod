using UnityEngine;
using GadgetCore.API;
using HarmonyLib;

namespace SystemCursorMod
{
    [Gadget("System Cursor Mod", true)]
    public class SystemCursorMod : Gadget<SystemCursorMod>
    {
        public const string MOD_VERSION = "1.0"; // Set this to the version of your mod.
        public const string CONFIG_VERSION = "1.0"; // Increment this whenever you change your mod's config file.

        private Harmony harmony = new Harmony("com.tien.systemcursormod");
		
		protected override void LoadConfig()
		{
			Config.Load();
			
			string fileVersion = Config.ReadString("ConfigVersion", CONFIG_VERSION);

            if (fileVersion != CONFIG_VERSION)
            {
                Config.Reset();
                Config.WriteString("ConfigVersion", CONFIG_VERSION);
            }
			
			// Do stuff with `Config`
			
			Config.Save();
		}
		
        public override string GetModDescription()
        {
            return "Removes the custom cursor of Roguelands in order to use the system cursor.";
        }

        protected override void Initialize()
        {
            Logger.Log("SystemCursorMod v" + Info.Mod.Version);

            // Apply all patches in the current assembly
            harmony.PatchAll();
        }

        protected override void Unload()
        {
            // Destroy the mod.
            harmony.UnpatchAll();
        }
    }
}
