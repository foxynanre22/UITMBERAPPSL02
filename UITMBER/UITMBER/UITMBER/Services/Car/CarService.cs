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
            //var url = $"{Settings.SERVER_ENDPOINT}/Car/GetMyCars";
            //var data = await _requestService.GetAsync<List<CarDto>>(url);
            List<CarDto> sd = new List<CarDto>();


            var result = new CarDto
            {
                Color = "White",
                Id = 1,
                IsActive = true,
                Manufacturer = "BlaBlacar",
                Model = "Tesla X",
                Photo = "https://upload.wikimedia.org/wikipedia/commons/0/0c/2017_Tesla_Model_X_front_5.27.18.jpg",
                PlateNo = "Jeden",
                Type = CarType.Seater7,
                UserId = 2,
                Year = 2020
            };
            var res2ult = new CarDto
            {
                Color = "Black",
                Id = 2,
                IsActive = true,
                Manufacturer = "BlaBlacar",
                Model = "Tesla MX",
                Photo = "https://cdn.riastatic.com/photosnewr/auto/new_auto_storage/tesla-model-x__664102-620x465x70.jpg",
                PlateNo = "Dwa",
                Type = CarType.Seater7,
                UserId = 2,
                Year = 2020
            };
            sd.Add(result);
            sd.Add(res2ult);

            return sd;
        }

        public async Task<string> Update(CarDto car)
        {
            var url = $"{Settings.SERVER_ENDPOINT}/Car/Update";
            var result = await _requestService.PutAsync<CarDto, string>(url, car);

            return result;
        }
    }
}
