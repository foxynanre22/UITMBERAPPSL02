using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.UserFavouriteLocation;
using UITMBER.Services.Request;
using Xamarin.Forms;

namespace UITMBER.Services.UFLocations
{
    class UFLocationsService : IUFLocationsService
    {
        private IRequestService _requestService => DependencyService.Get<IRequestService>();
        public async Task<bool> AddLocations(LocationDto LoDto)
        {
            var url = $"{Settings.SERVER_ENDPOINT}/UFLocations/AddLocation";
            await _requestService.PostAsync<LocationDto>(url, LoDto);

            return true;
        }

        public async Task<List<UserFavouriteLocation>> GetMyLocations()
        {
            var url = $"{Settings.SERVER_ENDPOINT}/UFLocations/GetMyLocations";
            var data = await _requestService.GetAsync<List<UserFavouriteLocation>>(url);

            return data;
        }
        
    }
}
