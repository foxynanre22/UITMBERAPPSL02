using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UITMBER.Models.UserFavouriteLocation;
using UITMBER.Services.UFLocations;
using UITMBER.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class LocationDetailViewModel :BaseViewModel
    {

        private Xamarin.Forms.Maps.Map mapControl;
        public Xamarin.Forms.Maps.Map MapControl
        {
            get => mapControl;
            set => SetProperty(ref mapControl, value);
        }
        private string itemId;
         public string ItemId
        {
            get => itemId;
            set 
            { 
                SetProperty(ref itemId, value);
                LoadItemId(value);
            }
        }
        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private double lat;
        public double Lat
        {
            get => lat;
            set => SetProperty(ref lat, value);
        }
        private double longi;
        public double Long
        {
            get => longi;
            set => SetProperty(ref longi, value);
        }
        public Command DeleteItemCommand { get; }
        UFLocationsService _ufLocationsService = new UFLocationsService();


        public LocationDetailViewModel()
        {
            DeleteItemCommand = new Command(DeleteCommand);
            
        }
         

        private async void DeleteCommand(object obj)
        {
            var result = _ufLocationsService.DeleteLocation(Convert.ToInt64(itemId));
            await Shell.Current.GoToAsync($"//{nameof(UFLocationPage)}");
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var items = await _ufLocationsService.GetMyLocations();
               
                foreach (var item in items)
                {
                    if(item.Id == Convert.ToInt64(itemId))
                    {
                        Lat = item.Lat;
                        Long = item.Long;
                        Name = item.Name;
                    }
                    
                }
                InitMap();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void InitMap()
        {
            var mapSpan = Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(Lat, Long), Xamarin.Forms.Maps.Distance.FromKilometers(3));

            MapControl = new Xamarin.Forms.Maps.Map(mapSpan);

            var placemarks = await Geocoding.GetPlacemarksAsync(Lat, Long);

            var placemark = placemarks?.FirstOrDefault();

            MapControl.Pins.Add(new Xamarin.Forms.Maps.Pin()
            {
                Position = new Xamarin.Forms.Maps.Position(Lat, Long),
                Label = placemark.Thoroughfare + " " + placemark.SubThoroughfare + ", " + placemark.Locality + " " + placemark.PostalCode,
                Type = Xamarin.Forms.Maps.PinType.Place
            });
        }
    }
}
