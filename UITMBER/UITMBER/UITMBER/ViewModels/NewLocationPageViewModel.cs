using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.UserFavouriteLocation;
using UITMBER.Services.UFLocations;
using UITMBER.Views;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    public class NewLocationPageViewModel : BaseViewModel
    {
        private double latitude;
        public double Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }
        private double longitude;
        public double Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
        }
        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }


        UFLocationsService _ufLocationsService = new UFLocationsService();
        public Command LocationCommand { get; }

        public NewLocationPageViewModel()
        {
            Title = "Dodaj ulubioną lokalizacje";
            LocationCommand = new Command(AddLocationCommand);
        }

        private  async void AddLocationCommand(object obj)
        {
            var location = await _ufLocationsService.GetMyLocations();
            var UserId = location[0].UserId;
            var result = _ufLocationsService.AddLocations(new LocationDto()
            {
                Lat = latitude,
                Long = longitude,
                Name = name,
                UserId = UserId
            });
            await Shell.Current.GoToAsync($"//{nameof(UFLocationPage)}");
        }
    }
}



