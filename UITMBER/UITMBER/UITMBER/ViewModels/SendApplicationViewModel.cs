using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Application;
using UITMBER.Models.Car;
using UITMBER.Services.Application;
using UITMBER.Services.Car;
using UITMBER.Services.Clients;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UITMBER.ViewModels
{
    public class SendApplicationViewModel : BaseViewModel
    {
        ApplicationService applicationService => new ApplicationService();
        CarService carService => new CarService();

        long userid;
        long selectedCarId;
        string selectedCarModel;

        private string licenceNr;
        public string LicenceNr
        {
            get { return licenceNr; }
            set
            {
                if (licenceNr != value)
                {
                    licenceNr = value;

                }
            }
        }

        private string licenceImg;
        public string LicenceImg
        {
            get { return licenceImg; }
            set
            {
                if (licenceImg != value)
                {
                    licenceImg = value;

                }
            }
        }


        public IList<string> carList = new List<string>();
        public IList<string> CarList
        {
            get => carList;
        }

        public Command SendCommand { get; }
        public Command PickerCommand { get; }

        private string pickerSelectedItem { get; set; }
        public string PickerSelectedItem
        {
            get { return pickerSelectedItem; }
            set
            {
                if (pickerSelectedItem != value)
                {
                    pickerSelectedItem = value;
                    selectedCarModel = pickerSelectedItem;
                    OnPropertyChanged();
                }
            }
        }


        public SendApplicationViewModel()
        {
            SendCommand = new Command(OnSendClicked);
            Cars();
        }

        private async void OnSendClicked(object obj)
        {
            var cars = await carService.GetMyCars();
            foreach (CarDto car in cars)
            {
                if (car.Model == selectedCarModel)
                {
                    selectedCarId = car.Id;
                }
            }
            await applicationService.SendApplication(new SendApplicationRequest
            {
                CarId = selectedCarId,
                Date = DateTime.Now,
                DriverLicenceNo = licenceNr,
                DriverLicencePhoto = licenceImg,
                UserId = userid

            });
        }

        public async void Cars()
        {
            var cars = await carService.GetMyCars();
            userid = cars[0].UserId;
            foreach (CarDto car in cars)
            {
                carList.Add(car.Model);
            }
        }

        //W MyApplicationPage.xaml
    }
}
