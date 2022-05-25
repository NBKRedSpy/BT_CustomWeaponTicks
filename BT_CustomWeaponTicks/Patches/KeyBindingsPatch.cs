using BattleTech;
using BattleTech.UI;
using Harmony;
using InControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_CustomWeaponTicks.Patches
{
    public class KeyBindingsPatch
    {
        public class Adapter<T>
        {
            public readonly T instance;
            public readonly Traverse traverse;

            protected Adapter(T instance)
            {
                this.instance = instance;
                traverse = Traverse.Create(instance);
            }
        }

        public static PlayerAction SelectNextTickColor;


        [HarmonyPatch(typeof(UIManager), "Update")]
        public static class UIManager_Patch
        {

            //Debug
            public static bool _logged;

            public static void Prefix(UIManager __instance)
            {
                try
                {
                    if (!Core.ModSettings.NextColorKeyBinding.Active) return;

                    if (SelectNextTickColor.WasReleased)
                    {
                        Logger.Log("Key fired");

                        if (Core.ModSettings.ColorSets.Count == 0) return;

                        ColorSet colorSet = Core.ModSettings.ColorSets.Next();

                        colorSet.SetTickColors(__instance);

                        //Debug
                        Logger.Log("Set complete");
                        
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(ex);
                }
            }
        }


        [HarmonyPatch(typeof(DynamicActions), "CreateWithDefaultBindings")]
        public static class DynamicActionsCreateWithDefaultBindingsPatch
        {
            public static void Postfix(DynamicActions __result)
            {

                try
                {
                    if (Core.ModSettings.NextColorKeyBinding.Active)
                    {
                            var adapter = new DynamicActionsAdapter(__result);
                            SelectNextTickColor = adapter.CreatePlayerAction("Select next tick color");
                            SelectNextTickColor.AddDefaultBinding(Core.ModSettings.NextColorKeyBinding.Keys);
                            Logger.Log("Keybind added");
                    }
                }
                    catch (Exception e)
                {
                    Logger.Log(e);
                }

            }
        }

        internal class DynamicActionsAdapter : Adapter<DynamicActions>
        {
            internal DynamicActionsAdapter(DynamicActions instance) : base(instance) { }

            internal PlayerAction CreatePlayerAction(string name)
            {
                return traverse.Method("CreatePlayerAction", name).GetValue<PlayerAction>(name);
            }
        }
    }
}
