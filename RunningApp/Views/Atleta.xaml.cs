using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;


using RunningApp.Models;
using Map = Xamarin.Forms.Maps.Map;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RunningApp.Views
{
    
    [DesignTimeVisible(false)]
    public partial class Atleta : ContentPage
    {
        public Item Item { get; set; }

        Position mapPosition;
        Location userLocation;

        public Atleta()
        {
            InitializeComponent();

            BindingContext = this;
            
          
        }

        protected override async void OnAppearing() {

            base.OnAppearing();
            await FindUserLocation();

            if (userLocation != null)
                return;

            mapPosition = new Position(userLocation.Latitude, userLocation.Longitude);



            MapView.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    mapPosition, Distance.FromMiles(1)));
            
        }
        async Task FindUserLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                userLocation = await Geolocation.GetLastKnownLocationAsync();
                Debug.WriteLine(userLocation?.ToString() ?? "no location");
                userLocation = await Geolocation.GetLocationAsync(request);
                Debug.WriteLine(userLocation?.ToString() ?? "no location");
            }
            catch (FeatureNotSupportedException fnsEx) {
                Debug.WriteLine(fnsEx);
            }
            catch (PermissionException pEx) {
                Debug.WriteLine(pEx);
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);
            }
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
             // Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }
    }
}