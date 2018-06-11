using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace estimoteXamarin.Models
{
    public class Beacon
    {
        public Beacon(string deviceId, IDictionary<string, string> attachments)
        {
            if (!attachments.TryGetValue("AuparBusiness", out string name))
            {
                name = "Undefined";
            }

            Color color = new Color();
            if (attachments.TryGetValue("Color", out string colorString))
            {
                color = Color.FromHex(colorString);
            }
            else
            {
                color = Color.Default;
            }

            this.Name = name;
            this.Color = color;
            this.Attachments = attachments;
        }

        public string Name { get; private set; }
        public IDictionary<string, string> Attachments { get; private set; }
        public Color Color { get; private set; }
    }
}
