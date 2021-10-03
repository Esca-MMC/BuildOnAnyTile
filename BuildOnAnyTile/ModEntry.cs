using HarmonyLib;
using StardewModdingAPI;
using System;

namespace BuildOnAnyTile
{
    public partial class ModEntry : Mod
    {
        public static Mod Instance { get; set; } = null;
        public static ModConfig Config { get; set; } = null;

        public override void Entry(IModHelper helper)
        {
            Instance = this; //provide a static reference to this mod's utilities

            try
            {
                Config = helper.ReadConfig<ModConfig>(); //try to load the config.json file
            }
            catch (Exception ex)
            {
                Monitor.Log($"Encountered an error while loading the config.json file. Default settings will be used instead. Full error message:\n-----\n{ex.ToString()}", LogLevel.Error);
                Config = new ModConfig(); //use the default settings
            }

            ApplyHarmonyPatches();
            
            Helper.Events.Display.RenderedActiveMenu += EnableGMCM; //enable GMCM compatibility when a menu is drawn (due to i18n timing issues with GMCM and SDV 1.5.5+, as of this writing)
        }

        /// <summary>Applies any Harmony patches used by this mod.</summary>
        private void ApplyHarmonyPatches()
        {
            Harmony harmony = new Harmony(ModManifest.UniqueID); //create this mod's Harmony instance

            HarmonyPatch_BuildOnAnyTile.ApplyPatch(harmony);
        }
    }
}
