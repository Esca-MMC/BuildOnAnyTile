# Build On Any Tile
 A mod for the game Stardew Valley, allowing buildings to be placed on otherwise nonvalid tiles, such as water and other obstructions.

## Contents
* [Installation](#installation)
* [Options](#options)
* [Translation](#translation)

## Installation
1. **Install the latest version of [SMAPI](https://smapi.io/).**
2. **Download Build On Any Tile** from [the Releases page on GitHub](https://github.com/Esca-MMC/BuildOnAnyTile/releases), Nexus Mods, or ModDrop.
3. **Unzip Build On Any Tile** into the `Stardew Valley\Mods` folder.

Multiplayer note:
* Each player who wants to place buildings on nonvalid tiles will need to install this mod, but it is not required otherwise.

## Options
Build On Any Tile includes options to enable or disable building placement on certain terrain types and obstructions.

To edit these options:

1. **Run the game** using SMAPI. This will generate the mod's **config.json** file in the `Stardew Valley\Mods\BuildOnAnyTile` folder.
2. **Exit the game** and open the **config.json** file with any text editing program.

This mod also supports [spacechase0](https://github.com/spacechase0)'s [Generic Mod Config Menu](https://spacechase0.com/mods/stardew-valley/generic-mod-config-menu/) (GMCM). Players with that mod will be able to change config.json settings from Stardew's main menu.

The available settings are:

Name | Valid settings | Description
-----|----------------|------------
BuildOnAllTerrainFeatures | **false**, true | Enable this to place buildings on crops, trees, and similar objects. **WARNING:** Buildings will immediately delete those objects when placed over them.
BuildOnOtherBuildings | **true**, false | Enable this to place buildings on tiles that already contain other buildings.
BuildOnWater | **true**, false | Enable this to place buildings on water tiles.
BuildOnImpassableTiles | **true**, false | Enable this to place buildings on impassable tiles, e.g. cliffs and other obstructions.
BuildOnNoFurnitureTiles | **true**, false | Enable this to place buildings on tiles with the "NoFurniture" property.
BuildOnCaveAndShippingZones | **true**, false | Enable this to place buildings on tiles in the preset cave entrance and shipping bin areas.

## Translation

Build On Any Tile supports translation of its Generic Mod Config Menu setting names and descriptions.

When Stardew Valley is launched, a file with the appropriate language code is loaded from `BuildOnAnyTile/i18n`, or [`default.json`](https://github.com/Esca-MMC/BuildOnAnyTile/blob/master/BuildOnAnyTile/i18n/default.json) if no specific translation exists.

See the Stardew Valley wiki's [Modding:Translations] page for more information. Please feel free to submit translation files via pull request, linking the file in a GitHub issue, or any other method.