﻿using BattleTech.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BT_CustomWeaponTicks
{
    public class ColorSet
    {

        public string Description { get; set; }
        public Color TickMarkOptimal { get; set; }
        public Color TickMarkNonOptimal { get; set; }
        public Color TickMarkTargetedOptimal { get; set; }
        public Color TickMarkTargetedNonOptimal { get; set; }


        public void SetTickColors(UIManager uiManager)
        {
            uiManager.UILookAndColorConstants.TickMarkOptimal.color = TickMarkTargetedOptimal;
            uiManager.UILookAndColorConstants.TickMarkNonOptimal.color = TickMarkNonOptimal;
            uiManager.UILookAndColorConstants.TickMarkTargetedOptimal.color = TickMarkTargetedOptimal;
            uiManager.UILookAndColorConstants.TickMarkTargetedNonOptimal.color = TickMarkTargetedNonOptimal;

            //debgug
            Logger.LogJson(new
            {
                TickMarkOptimal = uiManager.UILookAndColorConstants.TickMarkOptimal.color.ToString(),
                TickMarkNonOptimal = uiManager.UILookAndColorConstants.TickMarkNonOptimal.color.ToString(),
                TickMarkTargetedOptimal = uiManager.UILookAndColorConstants.TickMarkTargetedOptimal.color.ToString(),
                TickMarkTargetedNonOptimal = uiManager.UILookAndColorConstants.TickMarkTargetedNonOptimal.color.ToString(),
            });

        }

    }
}