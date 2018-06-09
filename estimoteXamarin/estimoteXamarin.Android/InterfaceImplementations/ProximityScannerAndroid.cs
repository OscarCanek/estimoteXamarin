using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Estimote.Android.Proximity;
using estimoteXamarin.Droid;
using estimoteXamarin.Models;
using Xamarin.Forms;
using Android.Content.PM;
using Android;
using Android.Support.V4.Content;

[assembly: Dependency(typeof(ProximityScannerAndroid))]

namespace estimoteXamarin.Droid
{
    public class ProximityScannerAndroid : IProximityScanner
    {
        private Notification notification;
        private List<IProximityZone> proximityZones = new List<IProximityZone>();

        public IProximityObserver Observer { get; private set; }
        public IProximityObserverHandler ObservationHandler { get; private set; }
        public ObservableCollection<EstimoteZoneEvent> Events => EstimoteElements.Events;
        public List<IProximityZone> ProximityZones => proximityZones;

        public void Initialize(object context)
        {
            Android.Content.Context castedContext = (Android.Content.Context)context;
            if (ContextCompat.CheckSelfPermission(castedContext, Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
            {
                Log.Debug("app", "Location permission denied");
                return;
            }
            
            this.CreateNotification(castedContext);
            this.CreateObserver(castedContext);
        }

        private void CreateNotification(Android.Content.Context context)
        {
            // starting with Android 8.0, the most reliable way to keep
            // Bluetooth scanning active is through a foreground service, and
            // for that to work we're required to show a notification that
            // informs the user about the activity
            //
            // read more about it on:
            // https://developer.android.com/guide/components/services.html#Foreground
            var channelId = "proximity_scanning";
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                // Android 8.0 and up require a channel for the notifications
                var channel = new NotificationChannel(channelId, "Bluetooth activity", NotificationImportance.Low);
                var notificationManager = Android.App.Application.Context.GetSystemService(Android.Content.Context.NotificationService) as NotificationManager;
                notificationManager.CreateNotificationChannel(channel);
            }

            notification = new NotificationCompat.Builder(context, channelId)
                    .SetSmallIcon(global::Android.Resource.Drawable.IcDialogInfo)
                    .SetContentTitle("Proximity")
                    .SetContentText("Proximity demo is scanning for beacons")
                    .Build();
        }

        private void CreateObserver(Android.Content.Context context)
        {
            var creds = new EstimoteCloudCredentials("test-xamarin-io8", "f03827075acaaba5b6fbc52436f1d4b6");

            Observer = new ProximityObserverBuilder(context, creds)
                .WithEstimoteSecureMonitoringDisabled()
                .WithTelemetryReportingDisabled()
                .WithBalancedPowerMode()
                .WithScannerInForegroundService(notification)
                .WithOnErrorAction(new ObservingErrorHandler())
                .Build();
        }

        public void AddZone(double range, string key, string value)
        {
            if (Observer == null)
            {
                Log.Debug("app", "Observer is not defined yet");
                return;
            }

            var newZone = Observer
            .ZoneBuilder()
                .ForAttachmentKeyAndValue(key, value)
                .InCustomRange(range)
                .WithOnEnterAction(new OnEnterZoneHandler())
                .WithOnChangeAction(new OnChangeZoneHandler())
                .WithOnExitAction(new OnExitZoneHandler())
                .Create();

            Observer.AddProximityZone(newZone);
            ProximityZones.Add(newZone);

            Log.Debug("app", "Proximity all ready to go!");
        }

        public void StartObservingZones()
        {
            if (Observer == null)
            {
                Log.Debug("app", "Observer is not defined yet");
                return;
            }

            Log.Debug("app", "Starting proximity observation");

            ObservationHandler = Observer.Start();
        }

        public void StopObservingZones()
        {
            if (ObservationHandler != null)
            {
                ObservationHandler.Stop();
            }
        }
    }
}