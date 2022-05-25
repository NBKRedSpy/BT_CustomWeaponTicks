using InControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BT_CustomWeaponTicks
{
    public class ModSettings
    {
        public float xScale { get; set; } = -1f;
        public float yScale { get; set; } = 1.5f;
        public float zScale { get; set; } = 1f;
        public float maxIndividualScale { get; set; } = 2f;

        //Debug - hardcode to shift b
        public KeyBindingSetting NextColorKeyBinding { get; set; } = new KeyBindingSetting()
        {
            active = true,
            Keys = new KeyCombo(Key.Shift, Key.T),
        };

    }
}
