using estimoteXamarin.Models;
using estimoteXamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace estimoteXamarin.Handlers
{
    public class ZoneEventHandler
    {
        private readonly DiscoverManager manager;
        private readonly List<DiscoverListElement> currentElements;

        public ZoneEventHandler(List<DiscoverListElement> currentElements)
        {
            this.currentElements = currentElements;
            manager = new DiscoverManager();
        }

        public async Task<Implementation> ChangeImplementation(EstimoteZoneEvent @event, Implementation currentImplementation)
        {
            if (@event.EventType == EstimoteZoneEventTypes.EXIT)
            {
                // pedir elementos del beacon virtual
                // una mejora es que aqui se muestren las recomendaciones obtenidas de ML
                // tambien se podría mostrar un mapa con las zonas aupar mas cercanas

                // save the implementation in the database
                ImplementationRepository implementationRepository = new ImplementationRepository();
                await implementationRepository.DeleteImplementation();

                return null;
            }
            else
            {
                Beacon beacon = new Beacon
                {
                    Id = @event.Beacon.DeviceId,
                    Uuid = @event.Beacon.Uuid,
                    Major = @event.Beacon.Major,
                    Minor = @event.Beacon.Minor
                };

                BeaconRepository beaconRepository = new BeaconRepository();

                // get the current implementation
                Implementation detectedImplementation = await beaconRepository.GetImplementation(beacon.Id);

                // whether the user enters to a diferent implementation than the current one
                if (currentImplementation == null || detectedImplementation == null || (currentImplementation != null && currentImplementation.Id != detectedImplementation.Id))
                {
                    // get the new implementation from the server
                    var newImplementation = await manager.GetImplementation(beacon);

                    // save the implementation in the database
                    ImplementationRepository implementationRepository = new ImplementationRepository();
                    await implementationRepository.ReplaceImplementation(newImplementation);

                    var scanner = DependencyService.Get<IProximityScanner>();

                    // stop observing proximity zones
                    scanner.StopObservingZones();

                    // dispose and delete custom proximity zones of the estimote proximity observer
                    scanner.ClearProximityZones();

                    // add new zones
                    newImplementation.ProximityZones.ForEach(x => scanner.AddCustomZone(x.Distance, Helpers.Settings.CustomProximityZoneKey, Helpers.Settings.CustomProximityZoneValue, x.Sectors.SelectMany(s => s.Beacons).Select(b => b.Id).ToArray()));
                    
                    // start observing the new proximity zones and old ones
                    scanner.StartObservingZones();

                    return newImplementation;
                }
                else
                {
                    return currentImplementation;
                }
            }
        }

        //public async Task<List<DiscoverListElement>> GetElementsToShow(EstimoteZoneEvent @event, Implementation currentImplementation, Sector currentSector)
        //{
        //    if (@event.EventType != EstimoteZoneEventTypes.EXIT)
        //    {
        //        Beacon beacon = new Beacon
        //        {
        //            Id = @event.Beacon.DeviceId,
        //            Uuid = @event.Beacon.Uuid,
        //            Major = @event.Beacon.Major,
        //            Minor = @event.Beacon.Minor
        //        };

        //        BeaconRepository beaconRepository = new BeaconRepository();

        //        // get the current implementation
        //        Implementation detectedImplementation = await beaconRepository.GetImplementation(beacon.Id);

        //        // whether the user enters to a diferent implementation than the current one
        //        if (currentImplementation == null || (currentImplementation != null && currentImplementation.Id != detectedImplementation.Id))
        //        {
        //            // change color and logo

        //            // save the implementation in the database
        //            ImplementationRepository implementationRepository = new ImplementationRepository();
        //            await implementationRepository.ReplaceImplementation(detectedImplementation);

        //            // returns new elements from the server 
        //            return await manager.GetElements(beacon);
        //        }
        //        // whether the user stays inside the same implementation
        //        else
        //        {
        //            return await GetElementsToShow(beacon, currentSector);
        //        }
        //    }
        //    else
        //    {
        //        return currentElements;
        //    }
        //}

        public async Task<Sector> GetSector(EstimoteZoneEvent @event, Sector currentSector)
        {
            BeaconRepository beaconRepository = new BeaconRepository();

            Beacon beacon = new Beacon
            {
                Id = @event.Beacon.DeviceId,
                Uuid = @event.Beacon.Uuid,
                Major = @event.Beacon.Major,
                Minor = @event.Beacon.Minor
            };

            // get the current implementation
            Implementation detectedImplementation = await beaconRepository.GetImplementation(beacon.Id);
            
            if (detectedImplementation == null)
            {
                return null;
            }

            if (@event.EventType != EstimoteZoneEventTypes.EXIT)
            {
                // get the current sector
                Sector detectedSector = await beaconRepository.GetSector(beacon.Id);

                // whether the user enters to a diferent sector than the current one
                if (currentSector == null || detectedSector == null || (currentSector != detectedSector))
                {
                    // update the current sector
                    return detectedSector;

                    // returns new elements from the server 
                    //return await manager.GetElements(beacon);
                }
                // whether the user stays inside the same sector
                else
                {
                    // returns the current list of elements
                    //return this.currentElements;
                    return currentSector;
                }
            }
            else
            {
                return currentSector;
            }
        }

        //private async Task<List<DiscoverListElement>> GetElementsToShow(Beacon beacon, Sector currentSector)
        //{
        //    BeaconRepository beaconRepository = new BeaconRepository();

        //    // get the current sector
        //    Sector detectedSector = await beaconRepository.GetSector(beacon.Major, beacon.Minor);

        //    // whether the user enters to a diferent sector than the current one
        //    if (currentSector == null || (currentSector != null && currentSector != detectedSector))
        //    {
        //        // update the current sector
        //        currentSector = detectedSector;

        //        // returns new elements from the server 
        //        return await manager.GetElements(beacon);
        //    }
        //    // whether the user stays inside the same sector
        //    else
        //    {
        //        // returns the current list of elements
        //        return this.currentElements;
        //    }
        //}

        public async Task<Sector> GetSector(Beacon beacon, Sector currentSector)
        {
            BeaconRepository beaconRepository = new BeaconRepository();

            // get the current sector
            Sector detectedSector = await beaconRepository.GetSector(beacon.Id);

            // whether the user enters to a diferent sector than the current one
            if (currentSector == null || (currentSector != null && currentSector != detectedSector))
            {
                // update the current sector
                return detectedSector;

                // returns new elements from the server 
                //return await manager.GetElements(beacon);
            }
            // whether the user stays inside the same sector
            else
            {
                // returns the current list of elements
                //return this.currentElements;
                return currentSector;
            }
        }
    }
}
