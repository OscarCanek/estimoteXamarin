using estimoteXamarin.Models;
using System.Collections.ObjectModel;

namespace estimoteXamarin
{
    public interface IProximityScanner
    {        
        ObservableCollection<EstimoteZoneEvent> Events { get; }

        void Initialize(object context);

        void AddZone(double range, string key, string value);

        void StartObservingZones();

        void StopObservingZones();
    }
}
