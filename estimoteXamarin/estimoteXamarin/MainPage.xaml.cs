using estimoteXamarin.Helpers;
using estimoteXamarin.Models;
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
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.Padding = new Thickness(20, 40, 20, 20);
                    break;
                default:
                    this.Padding = new Thickness(20);
                    break;
            }
            
            // Define some data.
            var beacons = DependencyService.Get<IProximityScanner>().Events;
            
            // Create the ListView.
            ListView beaconList = new ListView
            {
                // Source of data items.
                ItemsSource = beacons,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label
                    {
                        FontAttributes = FontAttributes.Bold
                    };

                    nameLabel.SetBinding(Label.TextProperty, "Beacon.Name");
                    
                    Label eventTypeLabel = new Label
                    {
                        FontAttributes = FontAttributes.Bold
                    };

                    eventTypeLabel.SetBinding(Label.TextProperty, "EventType");

                    Label dateLabel = new Label();
                    dateLabel.SetBinding(Label.TextProperty, new Binding("Date", BindingMode.OneWay, null, null, "{0:HH:mm:ss.fffff}"));

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "Beacon.Color");

                    Label attachmentsLabel = new Label();
                    attachmentsLabel.SetBinding(Label.TextProperty, "Beacon", converter: new AttachmentsConverter());

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                boxView,
                                new StackLayout
                                {
                                    VerticalOptions = LayoutOptions.Start,
                                    Spacing = 0,
                                    Children =
                                    {
                                        new StackLayout
                                        {
                                            Orientation = StackOrientation.Horizontal,
                                            HorizontalOptions = LayoutOptions.Start,
                                            Children =
                                            {
                                                nameLabel,
                                                eventTypeLabel,
                                                dateLabel
                                            }
                                        },
                                        new ScrollView
                                        {
                                            Orientation = ScrollOrientation.Horizontal,
                                            Content = attachmentsLabel
                                        }
                                    }
                                }
                            }
                        }
                    };
                })
            };
            
            beaconList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                // don't do anything if we just de-selected the row
                if (e.Item == null) return;
                // do something with e.SelectedItem
                ((ListView)sender).SelectedItem = null; // de-select the row
            };

            StackLayout panel = new StackLayout { Spacing = 15 };

            panel.Children.Add(new Label
            {
                Text = "Beacons",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            });

            panel.Children.Add(beaconList);

            this.Content = panel;
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
