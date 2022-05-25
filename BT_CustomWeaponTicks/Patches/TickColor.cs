using BattleTech;
using BattleTech.UI;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BT_CustomWeaponTicks.Patches
{
    [HarmonyPatch(typeof(CombatHUDWeaponTickMarks), "UpdateTicksShown")]
    public static class TickColor
    {

        public static bool ColorInited { get; set; } = false;

        public static Biome.BIOMESKIN? LastBiome { get; set; } //The last biome that was loaded.


        public static void Prefix(CombatHUDWeaponTickMarks __instance, UIManager ___uiManager)
        {

            try
            {
                //Exit if no colors defined.
                if (Core.ModSettings.ColorSets.Count == 0) return;

                if (ColorInited == false)
                {
                    Core.ModSettings.ColorSets[0].SetTickColors(___uiManager);
                    ColorInited = true;
                }

                Biome.BIOMESKIN currentBiome = UnityGameInstance.BattleTechGame.Combat.ActiveContract.ContractBiome;

                if (LastBiome.GetValueOrDefault(Biome.BIOMESKIN.UNDEFINED) == currentBiome)
                {
                    return;
                }


                //debug
                //UIColorRef colorRef = new UIColorRef()
                //{
                //    color = Color.blue,
                //    UIColor = UIColor.Custom,
                //};
                // ___uiManager.UILookAndColorConstants.TickMarkOptimal = colorRef;

                //Logger.Log($"Color set ");

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }


            


        }
    }
}
