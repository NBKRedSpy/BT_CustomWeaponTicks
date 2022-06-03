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

        public static void Prefix(CombatHUDWeaponTickMarks __instance, UIManager ___uiManager)
        {

            try
            {
                //Exit if no colors defined.
                if (Core.ModSettings.ColorSets.Count == 0) return;

                if (ColorInited == false)
                {
                    ColorSet defaultColor = Core.ModSettings.ColorSets.FirstOrDefault(x => x.IsDefault) ?? 
                        Core.ModSettings.ColorSets[0];

                    defaultColor.SetTickColors(___uiManager);

                    ColorInited = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }


            


        }
    }
}
