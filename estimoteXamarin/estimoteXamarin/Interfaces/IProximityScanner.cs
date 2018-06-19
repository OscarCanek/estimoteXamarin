using estimoteXamarin.Models;
using estimoteXamarin.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace estimoteXamarin
{
    public interface IProximityScanner
    {
        ObservableCollection<EstimoteZoneEvent> Events { get; set; }
        
        BeaconListViewModel Model { get; set; }

        void Initialize(object context);

        void AddDefaultZone();

        void AddCustomZone(double range, string key, string value, string[] beacons);

        void AddZones(double[] ranges, string key, string value);

        void StartObservingZones();

        void StopObservingZones();

        void ClearProximityZones();
    }
}
