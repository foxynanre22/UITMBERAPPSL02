using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Car;
using UITMBER.Services.Car;
using UITMBER.Views;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    class MyCarsViewModel : BaseViewModel
    {
        private CarDto _selectedItem;
        public ICarService _CarService => DependencyService.Get<ICarService>();

        public ObservableCollection<CarDto> CarsDto { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<CarDto> ItemTapped { get; }

        public MyCarsViewModel()
        {
            Title = "Browse";

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<CarDto>(OnItemSelected);
            CarsDto = new ObservableCollection<CarDto>();
            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {

                var getCars = await _CarService.GetMyCars();

                CarsDto.Clear();
                var items = await _CarService.GetMyCars();
                foreach (var item in items)
                {

                    CarsDto.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public CarDto SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewCarPage));
        }

        async void OnItemSelected(CarDto item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MyCarPage)}?{nameof(MyCarViewModel.ItemIdC)}={item.Id}");
        }
    }
}
