using estimoteXamarin.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimoteXamarin.ViewModels
{
    public class BeaconListViewModel : ReactiveObject
    {
        private readonly List<EstimoteZoneEvent> savedEvents = new List<EstimoteZoneEvent>();
        private readonly ObservableAsPropertyHelper<List<EstimoteZoneEvent>> events;
        private readonly ObservableAsPropertyHelper<string> scanning;
        private EstimoteZoneEvent lastReceivedEvent;
        private ObservableAsPropertyHelper<bool> pinned;
        private ObservableAsPropertyHelper<string> buttonText;

        public BeaconListViewModel()
        {
            AddToList = ReactiveCommand.CreateFromTask<EstimoteZoneEvent, List<EstimoteZoneEvent>>(@event => AddEventToList(@event));
            Pin = ReactiveCommand.CreateFromTask<bool, bool>(x => PinToBeacon());

            pinned = Pin.ToProperty(this, x => x.Pinned, false);

            buttonText = Pin.Select(x => x == true ? "Pinned" : "Pin").ToProperty(this, x => x.ButtonText, "Pin");

            this.WhenAnyValue(x => x.LastReceivedEvent)
                .Throttle(TimeSpan.FromMilliseconds(800), RxApp.MainThreadScheduler)
                .Where(x => x != null && !pinned.Value)
                .DistinctUntilChanged(new EventComparer())
                .InvokeCommand(AddToList);

            scanning = AddToList.IsExecuting
            .Select(x => x ? "Querying..." : "Scanning...")
            .ToProperty(this, x => x.Scanning, "Scanning...");

            AddToList.ThrownExceptions.Subscribe(ex => { Console.WriteLine("AddToList-Error: {0}", ex); });

            events = AddToList.ToProperty(this, x => x.EstimoteEvents, out events);
        }

        public ReactiveCommand<EstimoteZoneEvent, List<EstimoteZoneEvent>> AddToList { get; protected set; }

        public ReactiveCommand<bool, bool> Pin { get; protected set; }

        public EstimoteZoneEvent LastReceivedEvent
        {
            get
            {
                return lastReceivedEvent;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref lastReceivedEvent, value);
            }
        }

        public string ButtonText => buttonText.Value;

        public bool Pinned => pinned.Value;

        public string Scanning => scanning.Value;

        public List<EstimoteZoneEvent> EstimoteEvents => events.Value;

        private async Task<List<EstimoteZoneEvent>> AddEventToList(EstimoteZoneEvent @event)
        {
            await Task.Delay(150);
            savedEvents.Insert(0, @event);
            return new List<EstimoteZoneEvent>(savedEvents);
        }

        private async Task<bool> PinToBeacon()
        {
            if (pinned.Value)
            {
                this.LastReceivedEvent = new EstimoteZoneEvent(this.lastReceivedEvent.Beacon, this.lastReceivedEvent.EventType);
            }

            return await (pinned.Value ? Task.FromResult(false) : Task.FromResult(true));
        }

        private class EventComparer : EqualityComparer<EstimoteZoneEvent>
        {
            public override bool Equals(EstimoteZoneEvent x, EstimoteZoneEvent y)
            {
                if (x.EventType == EstimoteZoneEventTypes.EXIT && y.EventType == EstimoteZoneEventTypes.EXIT)
                {
                    return true;
                }

                if (x.Beacon.DeviceId == y.Beacon.DeviceId)
                {
                    if (y.EventType == EstimoteZoneEventTypes.EXIT)
                    {
                        return false;
                    }

                    if (x.EventType == EstimoteZoneEventTypes.EXIT && y.EventType != EstimoteZoneEventTypes.EXIT)
                    {
                        return false;
                    }
                }

                return false;
            }

            public override int GetHashCode(EstimoteZoneEvent obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}
