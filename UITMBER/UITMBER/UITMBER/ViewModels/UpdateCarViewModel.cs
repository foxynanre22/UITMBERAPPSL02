using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UITMBER.Extentions;
using UITMBER.Models.Car;
using UITMBER.Services.Car;
using UITMBER.Views;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    [QueryProperty(nameof(ItemmIdC), nameof(ItemmIdC))]
    public class UpdateCarViewModel : BaseViewModel
    {
        public ICarService _CarService => DependencyService.Get<ICarService>();
        public long userId;
        public string model;
        public string manufacturer;
        public string plateNo;
        public string photo;
        public string itemIdC;
        public int year;
        public string color;
        public CarType type;
        public long id;


        public UpdateCarViewModel()
        {
            UpdateCommand = new Command<long>(OnUpdate);
            CancelCommand = new Command(OnCancel);
           this.PropertyChanged +=
                (_, __) => UpdateCommand.ChangeCanExecute();
        }

        public bool ValidateSave(long id)
        {
            if (id == Id)
            {
                return !String.IsNullOrWhiteSpace(model)
                                && !String.IsNullOrWhiteSpace(manufacturer)
                                && !String.IsNullOrWhiteSpace(plateNo)
                                && !String.IsNullOrWhiteSpace(photo)
                                && !String.IsNullOrWhiteSpace(year.ToString())
                                && !String.IsNullOrWhiteSpace(color);
            }
            else
            {
                return false;
            }
        }
        public string Color
        {
            get => color;
            set => SetProperty(ref color, value);
        }

        public long Id
        {
            get => id;
            set => SetProperty(ref id, value);
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
        public List<string> CarsNames
        {
            get
            {
                return Enum.GetNames(typeof(CarType)).Select(b => b.SplitCamelCase()).ToList();
            }
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

        public string ItemmIdC
        {
            get
            {
                return itemIdC;
            }
            set
            {
                itemIdC = value;
                LoadItemId(value);

            }
        }

        public async void LoadItemId(string ItemIdC)
        {
            long x = Int64.Parse(ItemIdC);
            try
            {
                var items = await _CarService.GetMyCars();
                var item = items.Where(c => c.Id == x).FirstOrDefault();
                Id = item.Id;
                Color = item.Color;
                Photo = item.Photo;
                Model = item.Model;
                Year = item.Year;
                Manufacturer = item.Manufacturer;
                PlateNo = item.PlateNo;
                Type = (CarType)(Enums.CarType)item.Type;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }


        public Command UpdateCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {

            await Shell.Current.GoToAsync("../..");
        }

        private async void OnUpdate(long id)
        {       
            CarDto newItem = new CarDto()
            {
                Id = id,
                Model = Model,
                Color = Color,
                Manufacturer = Manufacturer,
                Photo = Photo,
                PlateNo = PlateNo,
                Year = Year,
                Type = Type
            };

            await _CarService.Update(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

