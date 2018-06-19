using Android.Util;
using Estimote.Android.Proximity;
using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
using estimoteXamarin.ViewModels;
using System;
using System.Linq;

namespace estimoteXamarin.Droid
{
    public class OnChangeCustomZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        private BeaconListViewModel model;
        private readonly string[] zoneBeacons;

        public OnChangeCustomZoneHandler(BeaconListViewModel model, string[] zoneBeacons)
        {
            if (zoneBeacons == null) throw new ArgumentNullException("zoneBeacons", "zoneBeacons is null on OnChangeCustomZoneHandler");
            if (model == null) throw new ArgumentNullException("model", "model is null on OnChangeCustomZoneHandler");

            this.model = model;
            this.zoneBeacons = zoneBeacons;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            try
            {
                var detectedBeacons = (Java.Util.AbstractCollection)p0;

                foreach (var item in detectedBeacons.ToArray())
                {
                    IProximityAttachment attachment = (IProximityAttachment)item;

                    Log.Debug("app", $"OnChangeZoneHandler: {attachment.DeviceId}");

                    if (zoneBeacons.Any(x => x == attachment.DeviceId))
                    {
                        this.model.LastReceivedEvent = new EstimoteZoneEvent(new DetectedBeacon(attachment.DeviceId, attachment.Payload), EstimoteZoneEventTypes.CHANGE);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Debug("app", $"OnChangeZoneHandler-Error: {e}");
            }

            return null;
        }
    }
}