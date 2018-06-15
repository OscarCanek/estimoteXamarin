using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace estimoteXamarin.Models
{
    public class DetectedBeacon
    {
        public DetectedBeacon(string deviceId, IDictionary<string, string> attachments)
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

            if (attachments.TryGetValue("uuid:major:minor", out string uuid_major_minor))
            {
                var info = uuid_major_minor.Split(':');
                if (!Guid.TryParse(info[0], out Guid uuid))
                {
                    this.Uuid = uuid;
                }

                if (int.TryParse(info[1], out int major))
                {
                    this.Major = major;
                }

                if (int.TryParse(info[2], out int minor))
                {
                    this.Minor = minor;
                }
            }

            this.Name = name;
            this.Color = color;
            this.Attachments = attachments;
            this.DeviceId = deviceId;
        }

        public string DeviceId { get; private set; }
        public string Name { get; private set; }
        public IDictionary<string, string> Attachments { get; private set; }
        public Color Color { get; private set; }
        public Guid Uuid { get; private set; }
        public int Major { get; private set; }
        public int Minor { get; private set; }
    }
}
