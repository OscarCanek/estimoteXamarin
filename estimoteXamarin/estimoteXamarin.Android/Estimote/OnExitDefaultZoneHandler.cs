using Android.Util;
using Estimote.Android.Proximity;
using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
using estimoteXamarin.ViewModels;
using System;
using System.Linq;

namespace estimoteXamarin.Droid
{
    public class OnExitDefaultZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        private BeaconListViewModel model;

        public OnExitDefaultZoneHandler(BeaconListViewModel model)
        {
            if (model == null) throw new ArgumentNullException("model", "model is null on OnExitCustomZoneHandler");

            this.model = model;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityAttachment attachment = (IProximityAttachment)p0;

            Log.Debug("app", $"OnExitZoneHandler: {attachment.DeviceId}");

            this.model.LastReceivedEventFromDefaultZone = new EstimoteZoneEvent(new DetectedBeacon(attachment.DeviceId, attachment.Payload), EstimoteZoneEventTypes.EXIT);

            return null;
        }
    }
}