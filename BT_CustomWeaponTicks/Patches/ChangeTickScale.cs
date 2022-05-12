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
    /// <summary>
    /// Change the size of combat weapons range chevrons.
    /// </summary>
    [HarmonyPatch(typeof(CombatHUDWeaponTickMarks), nameof(CombatHUDWeaponTickMarks.Init),
        new Type[] { typeof(CombatHUD) })]
    public static class ChangeTickScale
    {
        public static void Postfix(ref Vector3 ___origScale, ref float ___maxIndividualScale)
        {
            ___origScale = new Vector3(Core.ModSettings.xScale, Core.ModSettings.yScale, Core.ModSettings.zScale);
            ___maxIndividualScale = Core.ModSettings.maxIndividualScale;
        }
    }
}
