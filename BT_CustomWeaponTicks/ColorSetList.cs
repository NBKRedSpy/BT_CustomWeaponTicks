using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_CustomWeaponTicks
{
    public class ColorSetList : List<ColorSet>
    {
        public int CurrentIndex { get; set; } = 0;

        public ColorSet Next()
        {
            CurrentIndex = (CurrentIndex + 1) % this.Count;
            return this[CurrentIndex];

        }
    }
}
