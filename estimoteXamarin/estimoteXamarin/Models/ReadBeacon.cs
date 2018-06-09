using System;
using System.Collections.Generic;
using System.Text;

namespace estimoteXamarin.Models
{
    public class ReadBeacon
    {
        public ReadBeacon(string deviceId, IDictionary<string, string> attachments)
        {
            this.DeviceId = deviceId;
            this.Attachments = attachments;
        }

        public string DeviceId { get; private set; }

        public IDictionary<string, string> Attachments { get; private set; }
    }
}
