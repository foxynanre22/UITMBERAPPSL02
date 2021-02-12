using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.UserFavouriteLocation;
using UITMBER.Services.UFLocations;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    public class UFLocationsViewModel : BaseViewModel
    {
        public IUFLocationsService _ufLocationsService => DependencyService.Get<IUFLocationsService>();

        private LocationDto _selectedItem;

        public ObservableCollection<LocationDto> Locations { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<LocationDto> ItemTapped { get; }

        public UFLocationsViewModel()
        {
            Title = "Ulubione lokalizacje";
            Locations = new ObservableCollection<LocationDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<LocationDto>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Locations.Clear();
                var locations = await _ufLocationsService.GetMyLocations();
                var items = locations.Select(x => x.ToLocationDto());

                foreach (var item in items)
                {
                    Locations.Add(item);
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

        public LocationDto SelectedItem
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
            //TODO Add "add location" page
            //await Shell.Current.GoToAsync(nameof(NewLocationPage));
        }

        async void OnItemSelected(LocationDto item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //TODO Add "location detail Page"
            //await Shell.Current.GoToAsync($"{nameof(LocationDetailPage)}?{nameof(LocationDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
