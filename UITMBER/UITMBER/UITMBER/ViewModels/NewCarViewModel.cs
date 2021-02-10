using System;
using System.Collections.Generic;
using System.Text;
using UITMBER.Models.Car;
using UITMBER.Services.Car;
using UITMBER.Views;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    public class NewCarViewModel : BaseViewModel
    {
        public ICarService _CarService => DependencyService.Get<ICarService>();
        public long userId;
        public string model;
        public string manufacturer;
        public string plateNo;
        public string photo;
        public int year;
        public string color;
        public CarType type;



        public NewCarViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(model)
                && !String.IsNullOrWhiteSpace(manufacturer)
                && !String.IsNullOrWhiteSpace(plateNo)
                && !String.IsNullOrWhiteSpace(photo)
                && !String.IsNullOrWhiteSpace(color);

        }
        public string Color
        {
            get => color;
            set => SetProperty(ref color, value);
        }
        public string PlateNo
        {
            get => plateNo;
            set => SetProperty(ref plateNo, value);
        }
        public CarType Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }
        public string Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }
        public string Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }
        public long UserId
        {
            get => userId;
            set => SetProperty(ref userId, value);
        }
        public string Manufacturer
        {
            get => manufacturer;
            set => SetProperty(ref manufacturer, value);
        }
        public int Year
        {
            get => year;
            set => SetProperty(ref year, value);
        }
        

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            //await Shell.Current.GoToAsync(nameof(UpdateCarPage));
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            byte[] gb = Guid.NewGuid().ToByteArray();
            long id = BitConverter.ToInt64(gb, 0);

            CarDto newItem = new CarDto()
            {
                Id = id,
                Model = Model,
                Color = Color,
                Manufacturer= Manufacturer,
                Photo=Photo,
                PlateNo = PlateNo,
                UserId=UserId,
                Year=Year,
                Type = Type
            };

            await _CarService.Add(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
