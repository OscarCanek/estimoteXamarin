using Android.Util;
using Estimote.Android.Proximity;
using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
using estimoteXamarin.ViewModels;
using System;
using System.Linq;

namespace estimoteXamarin.Droid
{
    public class OnExitZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        private BeaconListViewModel model;

        public OnExitZoneHandler(BeaconListViewModel model)
        {
            this.model = model;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityAttachment attachment = (IProximityAttachment)p0;

            Log.Debug("app", $"OnExitZoneHandler: {attachment.DeviceId}");

            this.model.LastReceivedEvent = new EstimoteZoneEvent(new Beacon(attachment.DeviceId, attachment.Payload), EstimoteZoneEventTypes.EXIT);

            return null;
        }
    }
}