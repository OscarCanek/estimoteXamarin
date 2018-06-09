using Android.Util;
using System.Linq;
using Estimote.Android.Proximity;
using estimoteXamarin.Helpers;
using estimoteXamarin.Models;

namespace estimoteXamarin.Droid
{
    public class OnEnterZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityAttachment attachment = (IProximityAttachment)p0;

            Log.Debug("app", $"OnEnterZoneHandler");

            var beaconRead = new ReadBeacon(attachment.DeviceId, attachment.Payload);
            Beacon beacon = beaconRead.ToBeacon();
            EstimoteElements.Events.Insert(0, new EstimoteZoneEvent(beacon, EstimoteZoneEventTypes.ENTER));

            return null;
        }
    }
}