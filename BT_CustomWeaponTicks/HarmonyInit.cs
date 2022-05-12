using Harmony;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BT_CustomWeaponTicks
{
    public static class HarmonyInit
    {
        public static void Init(string directory, string settingsJSON)
        {
            ModSettings modSettings = JsonConvert.DeserializeObject<ModSettings>(settingsJSON);
            Core.ModSettings = modSettings;

            var harmony = HarmonyInstance.Create("io.github.nbk_redspy.BT_CustomWeaponTicks");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
