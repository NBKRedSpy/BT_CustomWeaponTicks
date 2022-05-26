using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace BT_CustomWeaponTicks.JsonConverters
{
    public class ColorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return Type.Equals(objectType, typeof(Color));
        }

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string colorString = (string)reader.Value;

            Logger.Log($"color: {colorString}");

            return HexToColor(colorString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the hex colors eg (0099FF) to Unreal's float format.
        /// </summary>
        private Color HexToColor(string hexColorCode)
        {

            List<byte> rgbBytes = new List<byte>();


            for (int i = 0; i < 6; i += 2)
            {
                rgbBytes.Add(Convert.ToByte (hexColorCode.Substring(i, 2), 16));
            }

            return new Color(rgbBytes[0] / 255f, rgbBytes[1] / 255f, rgbBytes[2] / 255f);
        }
    }
}
