using Estimote.Android.Proximity;
using estimoteXamarin.Models;
using System.Collections.ObjectModel;

namespace estimoteXamarin.Droid
{
    public class EstimoteElements
    {
        private static readonly ObservableCollection<EstimoteZoneEvent> events = new ObservableCollection<EstimoteZoneEvent>();        
        public static ObservableCollection<EstimoteZoneEvent> Events => events;
    }
}