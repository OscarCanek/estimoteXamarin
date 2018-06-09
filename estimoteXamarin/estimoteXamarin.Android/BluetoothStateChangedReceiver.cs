using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace estimoteXamarin.Droid
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    //[IntentFilter(new[] { "android.bluetooth.adapter.action.STATE_CHANGED" })]
    public class BluetoothStateChangedReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            string action = intent.Action;

            if (action.Equals(BluetoothAdapter.ActionStateChanged))
            {
                BluetoothManager btManager = (BluetoothManager)Android.App.Application.Context.GetSystemService(Context.BluetoothService);
                int state = intent.GetIntExtra(BluetoothAdapter.ExtraState, BluetoothAdapter.Error);
                var scanner = DependencyService.Get<IProximityScanner>() as ProximityScannerAndroid;
                
                switch (state)
                {
                    case (int)State.Off:
                        //btManager.Adapter.Enable();
                        break;
                    case (int)State.TurningOff:
                        scanner.StopObservingZones();
                        break;
                    case (int)State.On:
                        if (scanner.Observer != null)
                        {
                            scanner.Initialize(context);
                            scanner.AddZone(1, "AuparZone", "InBusiness");
                        }

                        scanner.StartObservingZones();
                        break;
                    case (int)State.TurningOn:
                        break;
                }
            }
        }
    }
}