using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using RunningApp.Models;
using Xamarin.Forms.Internals;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RunningApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Iniciante : ContentPage
    {
        public Item Item { get; set; }

        Position mapPosition;
        Location userLocation;

        public Iniciante()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }
        protected override async void OnAppearing()
        {

            base.OnAppearing();
            await FindUserLocation();

        }
        async Task FindUserLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                userLocation = await Geolocation.GetLastKnownLocationAsync();

                userLocation = await Geolocation.GetLocationAsync(request);
                Log.Warning("Erro no mapa Iniciante", userLocation?.ToString() ?? "no location");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Debug.WriteLine(fnsEx);
            }
            catch (PermissionException pEx)
            {
                Debug.WriteLine(pEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            if (userLocation == null)
                return;
            mapPosition = new Position(userLocation.Latitude, userLocation.Longitude);
            InicianteMap.MoveToRegion(new MapSpan(mapPosition, 0.01, 0.01));
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
