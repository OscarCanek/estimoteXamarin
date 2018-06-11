using Android.Util;
using Estimote.Android.Proximity;
using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
using System;
using System.Linq;

namespace estimoteXamarin.Droid
{
    public class OnExitZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityAttachment attachment = (IProximityAttachment)p0;

            Log.Debug("app", $"OnExitZoneHandler: {attachment.DeviceId}");

            EstimoteElements.Events.Insert(0, new EstimoteZoneEvent(new Beacon(attachment.DeviceId, attachment.Payload), EstimoteZoneEventTypes.EXIT));

            return null;
        }
    }
}