using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
using estimoteXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace estimoteXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var model = new BeaconListViewModel();
            this.BindingContext = model;

            var scanner = DependencyService.Get<IProximityScanner>();
            scanner.Model = model;

            InitializeComponent();

            lstBeacons.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                // don't do anything if we just de-selected the row
                if (e.Item == null) return;
                // do something with e.SelectedItem
                ((ListView)sender).SelectedItem = null; // de-select the row
            };
        }

        protected override void OnAppearing()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var bt = DependencyService.Get<IBluetoothHandler>();
                await ValidateBTStatus(bt);
            });

            base.OnAppearing();
        }

        private async Task ValidateBTStatus(IBluetoothHandler bt)
        {
            if (!bt.IsEnabled())
            {
                if (await DisplayAlert(null, "Enable Bluetooth", "Yes", "No"))
                {
                    bt.Enable();
                }
                else
                {
                    await this.ValidateBTStatus(bt);
                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
