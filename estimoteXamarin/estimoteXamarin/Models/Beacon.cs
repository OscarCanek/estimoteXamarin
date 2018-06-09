using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace estimoteXamarin.Models
{
    public class Beacon
    {
        public Beacon(string name, Color color, IDictionary<string, string> attachments)
        {
            this.Name = name;
            this.Color = color;
            this.Attachments = attachments;
        }

        public string Name { get; private set; }
        public IDictionary<string, string> Attachments { get; private set; }
        public Color Color { get; private set; }
    }
}
