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
    public class OnEnterDefaultZoneHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        private BeaconListViewModel model;

        public OnEnterDefaultZoneHandler(BeaconListViewModel model)
        {
            if (model == null) throw new ArgumentNullException("model", "model is null on OnEnterCustomZoneHandler");

            this.model = model;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityAttachment attachment = (IProximityAttachment)p0;

            Log.Debug("app", $"OnEnterZoneHandler: {attachment.DeviceId}");

            this.model.LastReceivedEventFromDefaultZone = new EstimoteZoneEvent(new DetectedBeacon(attachment.DeviceId, attachment.Payload), EstimoteZoneEventTypes.ENTER);

            return null;
        }
    }
}