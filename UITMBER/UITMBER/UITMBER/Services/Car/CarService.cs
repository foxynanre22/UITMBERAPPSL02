using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Car;
using UITMBER.Services.Request;
using Xamarin.Forms;

namespace UITMBER.Services.Car
{
    public class CarService : ICarService
    {
        public IRequestService _requestService => DependencyService.Get<IRequestService>();

        public async Task<string> Add(CarDto car)
        {
            var url = $"{Settings.SERVER_ENDPOINT}/Car/Add";
            var result = await _requestService.PostAsync<CarDto, string>(url, car);

            return result;
        }

        public async Task<string> Delete(long carID)
        {
            var url = $"{Settings.SERVER_ENDPOINT}/Car/Delete/{carID}";
            var result = await _requestService.DeleteAsync<string>(url);

            return result;
        }

        public async Task<List<CarDto>> GetMyCars()
        {
            var url = $"{Settings.SERVER_ENDPOINT}/Car/GetMyCars";
            var data = await _requestService.GetAsync<List<CarDto>>(url);

            return data;
        }

        public async Task<string> Update(CarDto car)
        {
            var url = $"{Settings.SERVER_ENDPOINT}/Car/Update";
            var result = await _requestService.PutAsync<CarDto, string>(url, car);

            return result;
        }
    }
}
