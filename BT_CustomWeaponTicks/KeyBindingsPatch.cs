using BattleTech;
using BattleTech.UI;
using Harmony;
using InControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_CustomWeaponTicks
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

        public static PlayerAction SelectNextLineOfFireColor;


        [HarmonyPatch(typeof(UIManager), "Update")]
        public static class UIManager_Patch
        {
            public static bool Prefix(UIManager __instance)
            {
                if (!Core.ModSettings.NextColorKeyBinding.Active) return true;

                if (SelectNextLineOfFireColor.WasReleased)
                {
                    Logger.Log ($"Key bind executed");
                }

                return true;
            }
        }


        [HarmonyPatch(typeof(DynamicActions), "CreateWithDefaultBindings")]
        public static class DynamicActionsCreateWithDefaultBindingsPatch
        {
            public static void Postfix(DynamicActions __result)
            {
                if (Core.ModSettings.NextColorKeyBinding.Active)
                {
                    try
                    {
                        var adapter = new DynamicActionsAdapter(__result);
                        SelectNextLineOfFireColor = adapter.CreatePlayerAction("Select next tick color");
                        SelectNextLineOfFireColor.AddDefaultBinding(Core.ModSettings.NextColorKeyBinding.Keys);
                        Logger.Log("Keybind added");
                    }
                    catch (Exception e)
                    {
                        Logger.Log(e);
                    }
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
