using Android.Util;
using Estimote.Android.Proximity;
using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
using System;
using System.Linq;

namespace estimoteXamarin.Droid
{
    public class OnChangeZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            try
            {
                var x = (Java.Util.AbstractCollection)p0;

                foreach (var item in x.ToArray())
                {
                    IProximityAttachment attachment = (IProximityAttachment)item;

                    Log.Debug("app", $"OnChangeZoneHandler");

                    var beaconRead = new ReadBeacon(attachment.DeviceId, attachment.Payload);
                    Beacon beacon = beaconRead.ToBeacon();
                    EstimoteElements.Events.Insert(0, new EstimoteZoneEvent(beacon, EstimoteZoneEventTypes.CHANGE));
                }
            }
            catch (Exception e)
            {

            }

            return null;
        }
    }
}