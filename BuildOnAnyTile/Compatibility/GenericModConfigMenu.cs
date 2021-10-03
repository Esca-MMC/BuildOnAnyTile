using StardewModdingAPI;
using StardewModdingAPI.Events;
using System;

namespace BuildOnAnyTile
{
    public partial class ModEntry : Mod
    {
        /// <summary>True if the method <see cref="EnableGMCM"/> has already run. Does NOT indicate whether GMCM is available or this mod's menu was successfully enabled.</summary>
        private static bool InitializedGMCM { get; set; } = false;

        // <summary>A SMAPI GameLaunched event that enables GMCM support if that mod is available.</summary>
        public void EnableGMCM(object sender, RenderedActiveMenuEventArgs e)
        {
            if (InitializedGMCM)
                return; //do nothing
            InitializedGMCM = true; //don't run this more than once

            try
            {
                GenericModConfigMenuAPI api = Helper.ModRegistry.GetApi<GenericModConfigMenuAPI>("spacechase0.GenericModConfigMenu"); //attempt to get GMCM's API instance

                if (api == null) //if the API is not available
                    return;

                api.RegisterModConfig(ModManifest, () => Config = new ModConfig(), () => Helper.WriteConfig(Config)); //register "revert to default" and "write" methods for this mod's config
                api.SetDefaultIngameOptinValue(ModManifest, true); //allow in-game setting changes (rather than just at the main menu)

                //register an option for each of this mod's config settings
                api.RegisterSimpleOption
                (
                    ModManifest,
                    Helper.Translation.Get("BuildOnAllTerrainFeatures.Name"),
                    Helper.Translation.Get("BuildOnAllTerrainFeatures.Description"),
                    () => Config.BuildOnAllTerrainFeatures,
                    (bool val) => Config.BuildOnAllTerrainFeatures = val
                );

                api.RegisterSimpleOption
                (
                    ModManifest,
                    Helper.Translation.Get("BuildOnOtherBuildings.Name"),
                    Helper.Translation.Get("BuildOnOtherBuildings.Description"),
                    () => Config.BuildOnOtherBuildings,
                    (bool val) => Config.BuildOnOtherBuildings = val
                );

                api.RegisterSimpleOption
                (
                    ModManifest,
                    Helper.Translation.Get("BuildOnWater.Name"),
                    Helper.Translation.Get("BuildOnWater.Description"),
                    () => Config.BuildOnWater,
                    (bool val) => Config.BuildOnWater = val
                );

                api.RegisterSimpleOption
                (
                    ModManifest,
                    Helper.Translation.Get("BuildOnImpassableTiles.Name"),
                    Helper.Translation.Get("BuildOnImpassableTiles.Description"),
                    () => Config.BuildOnImpassableTiles,
                    (bool val) => Config.BuildOnImpassableTiles = val
                );

                api.RegisterSimpleOption
                (
                    ModManifest,
                    Helper.Translation.Get("BuildOnNoFurnitureTiles.Name"),
                    Helper.Translation.Get("BuildOnNoFurnitureTiles.Description"),
                    () => Config.BuildOnNoFurnitureTiles,
                    (bool val) => Config.BuildOnNoFurnitureTiles = val
                );

                api.RegisterSimpleOption
                (
                    ModManifest,
                    Helper.Translation.Get("BuildOnCaveAndShippingZones.Name"),
                    Helper.Translation.Get("BuildOnCaveAndShippingZones.Description"),
                    () => Config.BuildOnCaveAndShippingZones,
                    (bool val) => Config.BuildOnCaveAndShippingZones = val
                );
            }
            catch (Exception ex)
            {
                Monitor.Log($"An error happened while loading this mod's GMCM options menu. Its menu might be missing or fail to work. The auto-generated error message has been added to the log.", LogLevel.Warn);
                Monitor.Log($"----------", LogLevel.Trace);
                Monitor.Log($"{ex.ToString()}", LogLevel.Trace);
            }
        }
    }

    /// <summary>Generic Mod Config Menu's API interface. Used to recognize & interact with the mod's API when available.</summary>
    public interface GenericModConfigMenuAPI
    {
        void RegisterModConfig(IManifest mod, Action revertToDefault, Action saveToFile);
        void SetDefaultIngameOptinValue(IManifest mod, bool optedIn);
        void RegisterSimpleOption(IManifest mod, string optionName, string optionDesc, Func<bool> optionGet, Action<bool> optionSet);
    }
}
