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
        public static Biome.BIOMESKIN? LastBiome { get; set; } //The last biome that was loaded.


        public static void Prefix(CombatHUDWeaponTickMarks __instance, UIManager ___uiManager)
        {

            try
            {

                //Reset if no colors
                if (Core.ModSettings.ColorSets.Count == 0) return;

                Biome.BIOMESKIN currentBiome = UnityGameInstance.BattleTechGame.Combat.ActiveContract.ContractBiome;

                if (LastBiome.GetValueOrDefault(Biome.BIOMESKIN.UNDEFINED) == currentBiome)
                {
                    return;
                }

                UIColorRef colorRef = new UIColorRef()
                {
                    color = Color.blue,
                    UIColor = UIColor.Custom,
                };

                Logger.Log($"After color creation.  UiManager {___uiManager == null}");

                ___uiManager.UILookAndColorConstants.TickMarkOptimal = colorRef;

                Logger.Log($"Color set ");

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }


            


        }
    }
}
