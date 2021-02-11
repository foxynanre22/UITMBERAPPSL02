using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.UserFavouriteLocation;
using UITMBER.Services.UFLocations;
using UITMBER.Views;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    public class UFLocationsViewModel : BaseViewModel
    {
        public IUFLocationsService _ufLocationsService => DependencyService.Get<IUFLocationsService>();

        private UserFavouriteLocation _selectedItem;

        public ObservableCollection<UserFavouriteLocation> Locations { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<UserFavouriteLocation> ItemTapped { get; }

        public UFLocationsViewModel()
        {
            Title = "Ulubione lokalizacje";
            Locations = new ObservableCollection<UserFavouriteLocation>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<UserFavouriteLocation>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Locations.Clear();
                var locations = await _ufLocationsService.GetMyLocations();
               // var items = locations.Select(x => x.ToLocationDto());

                foreach (var item in locations)
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

        public UserFavouriteLocation SelectedItem
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
            await Shell.Current.GoToAsync(nameof(NewLocationPage));
        }

        async void OnItemSelected(UserFavouriteLocation item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(LocationDetailPage)}?{nameof(LocationDetailViewModel.ItemId)}={item.Id}");

        }
    }
}
