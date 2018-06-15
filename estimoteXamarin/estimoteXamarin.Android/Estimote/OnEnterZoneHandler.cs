using Android.Util;
using System.Linq;
using Estimote.Android.Proximity;
using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using estimoteXamarin.ViewModels;

namespace estimoteXamarin.Droid
{
    public class OnEnterZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        private BeaconListViewModel model;

        public OnEnterZoneHandler(BeaconListViewModel model)
        {
            this.model = model;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityAttachment attachment = (IProximityAttachment)p0;

            Log.Debug("app", $"OnEnterZoneHandler: {attachment.DeviceId}");

            this.model.LastReceivedEvent = new EstimoteZoneEvent(new DetectedBeacon(attachment.DeviceId, attachment.Payload), EstimoteZoneEventTypes.ENTER);

            return null;
        }
    }
}