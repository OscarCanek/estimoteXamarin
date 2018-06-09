using estimoteXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace estimoteXamarin.Helpers
{
    public static class ReadBeaconHelper
    {
        public static Beacon ToBeacon(this ReadBeacon beacon)
        {
            if (!beacon.Attachments.TryGetValue("AuparBusiness", out string name))
            {
                name = "Undefined";
            }

            Color color = new Color();
            if (beacon.Attachments.TryGetValue("Color", out string colorString))
            {
                color = Color.FromHex(colorString);
            }
            else
            {
                color = Color.Default;
            }

            return new Beacon(name, color, beacon.Attachments);
        }
    }
}
