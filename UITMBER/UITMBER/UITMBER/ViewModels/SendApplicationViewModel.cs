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
using System.Windows.Input;
using Xamarin.Essentials;
using System.IO;
using System.Collections.ObjectModel;

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

        private ImageSource imageSource;
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                    imageSource = value;
                    OnPropertyChanged();
               
               
            }
        }
        

        private string licenceImgBase64 = "";


        public ObservableCollection<string> CarList
        {
            get;
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

        public ICommand PickPhotoCommand => new Command(async () => await PickPhotoAsync());

        private async Task PickPhotoAsync()
        {
            try
            {
                if (!MediaPicker.IsCaptureSupported)
                    return;


                var file = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions() { Title = "DriverLicens" });

                if (file == null)
                    return;

                using (var stream = await file.OpenReadAsync())
                {
                    byte[] photoData = new byte[stream.Length];

                    stream.Read(photoData, 0, Convert.ToInt32(stream.Length));

                    licenceImgBase64 = Convert.ToBase64String(photoData);
                }



                ImageSource = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(licenceImgBase64)));
                

            }
            catch (Exception ex)
            {

            }
        }

        public SendApplicationViewModel()
        {
            SendCommand = new Command(OnSendClicked);
            licenceImgBase64 = "";
            CarList = new ObservableCollection<string>();
            ImageSource = ImageSource.FromFile("ic_user.png");
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
                CarList.Add(car.Model);
            }

            //OnPropertyChanged(nameof(CarList));
        }

        //W MyApplicationPage.xaml
    }
}
