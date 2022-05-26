# BT_CustomWeaponTicks
Customizes the color and size of the weapon range ticks in combat.

Makes the weapon range ticks easier to see by allows custom colors.  By default there are three color sets defined:
* Battletech default colors
* Lunar visibility colors
* Desert visibility colors

The user is able to cycle through the color schemes during combat using Ctrl+T

# mod.json Settings

## Custom Tick Colors


### Hotkey
The hotkey to cycle the tick colors defaults to Ctr+T, but can be changed via the nextColorKeyBinding value.

The binding will be displayed in Battletech's key configuration screen, but currently cannot be changed.

Setting|Default|Description|
|--|--|--|
```active```|true|enables the hotkey.  Leave as true.
```keys```|Ctrl + T| The hotkey to use to cycle the colors

### Color Sets
The colorSets array contains the colors to use.  Each object in the array is a color set.
There must be at least one color set, but there is no limit and the amount that can be defined.

|Setting|Description|
|-|-|
```isDefault ``` | True for the color set to default to .  If multiple are set then the first ```isDefault ``` set will be used.
```Description ``` | A friendly description used for user clarity.
```TickMarkOptimal ``` | Hex color for weapons in range.
```TickMarkNonOptimal ``` | Hex color for weapons in non-optimal range.
```TickMarkTargetedOptimal ``` | Hex color for weapons in range in first person  targeting mode.
```TickMarkTargetedNonOptimal ``` | Hex color for weapons in non-optimal range in first person targeting mode.

## Tick Size

The tick size defaults to Battletech's default.

Setting| Default | Description
|-|-|-|
|```xScale2 ``` | -1 | The width of the chevron.
|```yScale ``` | 1.5 |The height of the chevron
|```zScale ``` |  1 |The Z scale sent to the vector.  Not sure how it applies to a 2D element.  Just set to 1
|```maxIndividualScale```| 1.5 | Limits the growth of the ticks.


# Installation
To install, download the BT_CustomWeaponTicks.zip from the release section and extract to the Battletech Mods folder.

This assumes ModTek has been installed and injected.

# Compatibility
This should be compatible with all mods.

# Thanks

Special thanks to janxious, who's BTMLColorLOSMod mod I pulled the hotkey binding from.  
