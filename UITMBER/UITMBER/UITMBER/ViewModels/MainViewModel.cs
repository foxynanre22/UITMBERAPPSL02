using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;

namespace UITMBER.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        private Xamarin.Forms.Maps.Map mapControl;
        public Xamarin.Forms.Maps.Map MapControl
        {
            get => mapControl;
            set => SetProperty(ref mapControl, value);
        }

        public ICommand ActionCommand => new Command(async () => await GetCurrentLocation());

        public MainViewModel()
        {
            var mapSpan = Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(50.043604d, 22.0261172d), Xamarin.Forms.Maps.Distance.FromKilometers(3));

            MapControl = new Xamarin.Forms.Maps.Map(mapSpan);
            MapControl.IsShowingUser = true;

            MapControl.MapClicked += MapControl_MapClicked;

        }

        private async void MapControl_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            MapControl.Pins.Clear();

            var placemarks = await Geocoding.GetPlacemarksAsync(e.Position.Latitude, e.Position.Longitude);

            var placemark = placemarks?.FirstOrDefault();

            if(placemark != null)
            {
                MapControl.Pins.Add(new Xamarin.Forms.Maps.Pin()
                {
                    Position = e.Position,
                    Label = placemark.Thoroughfare + " " + placemark.SubThoroughfare + ", " + placemark.Locality + " " + placemark.PostalCode,
                    Type = Xamarin.Forms.Maps.PinType.SavedPin
                });
            }
            else
            {
                MapControl.Pins.Add(new Xamarin.Forms.Maps.Pin()
                {
                    Position = e.Position,
                    Label = "",
                    Type = Xamarin.Forms.Maps.PinType.SavedPin
                });
            }

          
        }

        private async Task GetCurrentLocation()
        {
            try
            {

                //var locations = await Geocoding.GetLocationsAsync("Paderewskiego Rzeszów");


                //var location = locations?.FirstOrDefault();

                //var mapSpan = Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(location.Latitude, location.Longitude), Xamarin.Forms.Maps.Distance.FromKilometers(.5));

                //MapControl.MoveToRegion(mapSpan);



                var location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                {
                    DesiredAccuracy = GeolocationAccuracy.Default
                });

                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Text = $"Lat: {location.Latitude} Long: {location.Longitude}";
                }

            }
            catch (FeatureNotSupportedException ex)
            {
                //Brak lokalizacji w urzadzeniu
            }
            catch (FeatureNotEnabledException ex)
            {
                //Lokalizacja off
            }
            catch (PermissionException ex)
            {
                //bark uprawnien do lokalizacji
            }
            catch (Exception ex)
            {

            }
        }
    }
}
