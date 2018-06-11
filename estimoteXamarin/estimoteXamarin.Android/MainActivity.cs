using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Estimote.Android.Proximity;
using Android.Support.V4.App;
using Android.Util;
using Android.Support.V4.Content;
using Android;
using Android.Content;
using Android.Bluetooth;
using Xamarin.Forms;

namespace estimoteXamarin.Droid
{
    [Activity(Label = "estimoteXamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        BluetoothStateChangedReceiver receiver;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            receiver = new BluetoothStateChangedReceiver();
        }

        // check and request permission to access location data
        //
        // code ported from:
        // https://developer.android.com/training/permissions/requesting.html
        // permisos riesgosos que necesitan concetimiento del usuario: https://developer.android.com/guide/topics/security/permissions#permission-groups

        private const int MY_PERMISSIONS_REQUEST_COARSE_LOCATION = 1;

        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(receiver, new IntentFilter(BluetoothAdapter.ActionStateChanged));

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
            {
                if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.AccessCoarseLocation))
                {
                    Log.Debug("app", "ShouldShowRequestPermissionRationale");

                    // we should show an extra dialog here to explain why we
                    // need the permission, and then follow up with an actual
                    // call to RequestPermissions ... but in this example, let's
                    // just call RequestPermissions straight away
                }

                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessCoarseLocation }, MY_PERMISSIONS_REQUEST_COARSE_LOCATION);
            }
            else
            {
                Log.Debug("app", "Already have the location permission");

                var scanner = DependencyService.Get<IProximityScanner>();
                scanner.Initialize(this);
                scanner.AddZone(0.2, "AuparZone", "InBusiness");
                //scanner.AddZone(0.3, "AuparZone", "InBusiness");
                //scanner.AddZone(0.4, "AuparZone", "InBusiness");
                //scanner.AddZone(0.5, "AuparZone", "InBusiness");
                //scanner.AddZone(0.6, "AuparZone", "InBusiness");
                //scanner.AddZone(0.7, "AuparZone", "InBusiness");
                //scanner.AddZone(0.8, "AuparZone", "InBusiness");
                //scanner.AddZone(0.9, "AuparZone", "InBusiness");
                //scanner.AddZone(1.1, "AuparZone", "InBusiness");
                //scanner.AddZone(1.2, "AuparZone", "InBusiness");
                //scanner.AddZone(1.3, "AuparZone", "InBusiness");
                //scanner.AddZone(1.4, "AuparZone", "InBusiness");
                //scanner.AddZone(1.5, "AuparZone", "InBusiness");
                //scanner.AddZone(1.6, "AuparZone", "InBusiness");
                //scanner.AddZone(1.7, "AuparZone", "InBusiness");
                //scanner.AddZone(1.8, "AuparZone", "InBusiness");
                //scanner.AddZone(1.9, "AuparZone", "InBusiness");
                //scanner.AddZone(2.1, "AuparZone", "InBusiness");
                //scanner.AddZone(2.2, "AuparZone", "InBusiness");
                //scanner.AddZone(2.3, "AuparZone", "InBusiness");
                //scanner.AddZone(2.4, "AuparZone", "InBusiness");
                //scanner.AddZone(2.5, "AuparZone", "InBusiness");
                //scanner.AddZone(2.6, "AuparZone", "InBusiness");
                //scanner.AddZone(2.7, "AuparZone", "InBusiness");
                //scanner.AddZone(2.8, "AuparZone", "InBusiness");
                //scanner.AddZone(2.9, "AuparZone", "InBusiness");
                //scanner.AddZone(3.1, "AuparZone", "InBusiness");
                //scanner.AddZone(3.2, "AuparZone", "InBusiness");
                //scanner.AddZone(3.3, "AuparZone", "InBusiness");
                //scanner.AddZone(3.4, "AuparZone", "InBusiness");
                //scanner.AddZone(3.5, "AuparZone", "InBusiness");
                //scanner.AddZone(3.6, "AuparZone", "InBusiness");
                //scanner.AddZone(3.7, "AuparZone", "InBusiness");
                //scanner.AddZone(3.8, "AuparZone", "InBusiness");
                //scanner.AddZone(3.9, "AuparZone", "InBusiness");
                //scanner.AddZone(4.1, "AuparZone", "InBusiness");
                //scanner.AddZone(4.2, "AuparZone", "InBusiness");
                //scanner.AddZone(4.3, "AuparZone", "InBusiness");
                //scanner.AddZone(4.4, "AuparZone", "InBusiness");
                //scanner.AddZone(4.5, "AuparZone", "InBusiness");
                //scanner.AddZone(4.6, "AuparZone", "InBusiness");
                //scanner.AddZone(4.7, "AuparZone", "InBusiness");
                //scanner.AddZone(4.8, "AuparZone", "InBusiness");
                //scanner.AddZone(4.9, "AuparZone", "InBusiness");
                //scanner.AddZone(5.1, "AuparZone", "InBusiness");
                //scanner.AddZone(5.2, "AuparZone", "InBusiness");
                //scanner.AddZone(5.3, "AuparZone", "InBusiness");
                //scanner.AddZone(5.4, "AuparZone", "InBusiness");

                //var ranges = new double[] { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7, 2.8, 2.9, 3.1, 3.2, 3.3, 3.4, 3.5, 3.6, 3.7, 3.8, 3.9, 4.1, 4.2, 4.3, 4.4, 4.5, 4.6, 4.7, 4.8, 4.9, 5.1, 5.2, 5.3, 5.4 };

                //scanner.AddZones(ranges, "uuid:major:minor", "8d1bc21c-4654-9a80-bc69-5c13ea70df3e:36388:57521");

                scanner.StartObservingZones();
            }
        }

        protected override void OnPause()
        {
            UnregisterReceiver(receiver);
            base.OnPause();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            switch (requestCode)
            {
                case MY_PERMISSIONS_REQUEST_COARSE_LOCATION:
                    {
                        if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                        {
                            Log.Debug("app", "Location permission granted");

                            var scanner = DependencyService.Get<IProximityScanner>();
                            scanner.Initialize(this);
                            scanner.AddZone(1, "AuparZone", "InBusiness");
                            scanner.StartObservingZones();
                        }
                        else
                        {
                            Log.Debug("app", "Location permission denied");
                        }

                        return;
                    }
            }
        }
    }
}

