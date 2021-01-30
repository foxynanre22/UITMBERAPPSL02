using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models;
using UITMBER.Models.Dto;
using UITMBER.Services.Request;

namespace UITMBER.Services.Client.Drivers
{
    class DriverService : IDriversService
    {
        private RequestService _requestService;

        public DriverService()
        {
            _requestService = new RequestService();
        }

        public async Task<List<DriverDto>> GetNerbyDriveres(LatLong latlong)
        {
            var url = $"/Driver/GetNerbyDriveres?latitude={latlong.Lat}&longitude={latlong.Long}";
            var data = await _requestService.GetAsync<List<DriverDto>>(url);

            return data;
        }

        public async Task<DriverDto> GetProfile(int driverId)
        {
            var url = $"/Driver/GetProfile?id={driverId}";
            var data = await _requestService.GetAsync<DriverDto>(url);

            return data;
        }
    }
}
