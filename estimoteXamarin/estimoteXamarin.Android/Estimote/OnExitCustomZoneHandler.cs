using Android.Util;
using Estimote.Android.Proximity;
using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
using estimoteXamarin.ViewModels;
using System;
using System.Linq;

namespace estimoteXamarin.Droid
{
    public class OnExitCustomZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        private BeaconListViewModel model;
        private readonly string[] zoneBeacons;

        public OnExitCustomZoneHandler(BeaconListViewModel model, string[] zoneBeacons)
        {
            if (zoneBeacons == null) throw new ArgumentNullException("zoneBeacons", "zoneBeacons is null on OnExitCustomZoneHandler");
            if (model == null) throw new ArgumentNullException("model", "model is null on OnExitCustomZoneHandler");

            this.model = model;
            this.zoneBeacons = zoneBeacons;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityAttachment attachment = (IProximityAttachment)p0;

            Log.Debug("app", $"OnExitZoneHandler: {attachment.DeviceId}");

            if (zoneBeacons.Any(x => x == attachment.DeviceId))
            {
                this.model.LastReceivedEvent = new EstimoteZoneEvent(new DetectedBeacon(attachment.DeviceId, attachment.Payload), EstimoteZoneEventTypes.EXIT);
            }

            return null;
        }
    }
}