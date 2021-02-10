using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UITMBER.Enums;
using UITMBER.Services.Car;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    [QueryProperty(nameof(ItemIdC), nameof(ItemIdC))]
    class MyCarViewModel : BaseViewModel
    {
        public Command DeleteItemCommand { get; }

        private string itemIdC;
        public ICarService _CarService => DependencyService.Get<ICarService>();
        public long id;
        public long userId;
        public string model;
        public string manufacturer;
        public string plateNo;
        public string photo;
        public int year;
        public string color;
        public CarType type;


        public MyCarViewModel()
        {
           DeleteItemCommand = new Command<long>(OnDeleteItem);
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

        public string ItemIdC
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
            int x = Int32.Parse(ItemIdC);
            try
            {
                    var items = await _CarService.GetMyCars(); 
                    var item =  items.Where(c => c.Id == x).FirstOrDefault();                  
                        Id = item.Id;
                        Color = item.Color;
                        Photo = item.Photo;
                        Model = item.Model;
                        Year = item.Year;
                        Manufacturer = item.Manufacturer;
                        PlateNo = item.PlateNo;
                        Type = (CarType)item.Type;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }


        private async void OnDeleteItem(long id)
        {           
            try
            {
               await _CarService.Delete(id);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
