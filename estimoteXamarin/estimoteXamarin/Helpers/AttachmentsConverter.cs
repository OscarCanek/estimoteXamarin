using estimoteXamarin.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace estimoteXamarin.Helpers
{
    public class AttachmentsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var beacon = (Beacon)value;
            return string.Join(" - ", beacon.Attachments.Select(kv => kv.Key + "=" + kv.Value).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
