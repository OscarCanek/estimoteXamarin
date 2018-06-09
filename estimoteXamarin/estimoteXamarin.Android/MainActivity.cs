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
                scanner.AddZone(1, "AuparZone", "InBusiness");
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

