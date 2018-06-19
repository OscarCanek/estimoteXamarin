using Android.Util;
using System.Linq;
using Estimote.Android.Proximity;
using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using estimoteXamarin.ViewModels;
using System;

namespace estimoteXamarin.Droid
{
    public class OnEnterCustomZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        private BeaconListViewModel model;
        private readonly string[] zoneBeacons;

        public OnEnterCustomZoneHandler(BeaconListViewModel model, string[] zoneBeacons)
        {
            if (zoneBeacons == null) throw new ArgumentNullException("zoneBeacons", "zoneBeacons is null on OnEnterCustomZoneHandler");
            if (model == null) throw new ArgumentNullException("model", "model is null on OnEnterCustomZoneHandler");

            this.model = model;
            this.zoneBeacons = zoneBeacons;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityAttachment attachment = (IProximityAttachment)p0;

            Log.Debug("app", $"OnEnterZoneHandler: {attachment.DeviceId}");

            if (zoneBeacons.Any(x => x == attachment.DeviceId))
            {
                this.model.LastReceivedEvent = new EstimoteZoneEvent(new DetectedBeacon(attachment.DeviceId, attachment.Payload), EstimoteZoneEventTypes.ENTER);
            }

            return null;
        }
    }
}