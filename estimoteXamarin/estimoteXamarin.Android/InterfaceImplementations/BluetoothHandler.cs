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
using estimoteXamarin.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothHandler))]

namespace estimoteXamarin.Droid
{
    class BluetoothHandler : IBluetoothHandler
    {
        private BluetoothManager _manager;

        public BluetoothHandler()
        {
            _manager = (BluetoothManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.BluetoothService);
        }

        public void Enable()
        {
            _manager.Adapter.Enable();            
        }

        public void Disable()
        {
            _manager.Adapter.Disable();            
        }

        public bool IsEnabled()
        {
            return _manager.Adapter.IsEnabled;
        }
    }
}