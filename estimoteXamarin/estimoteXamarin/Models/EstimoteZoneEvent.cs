using System;

namespace estimoteXamarin.Models
{
    public class EstimoteZoneEvent
    {
        public EstimoteZoneEvent(Beacon beacon, EstimoteZoneEventTypes eventType)
        {
            this.Beacon = beacon;
            this.EventType = eventType;
            this.Date = DateTime.Now;
        }

        public Beacon Beacon { get; private set; }
        public DateTime Date { get; private set; }
        public EstimoteZoneEventTypes EventType { get; private set; }
    }
}
